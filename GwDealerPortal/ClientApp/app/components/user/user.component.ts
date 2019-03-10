import { Component, Input } from "@angular/core";
import { CommonService } from "../../shared/common.service";
import { InterfaceModel } from "../../models/interface";
import { AppComponent } from "../app/app.component";
import { Router } from "@angular/router";
import { NgForm } from "@angular/forms";
declare var $: any;
declare var dpJs: any;
//declare var CanvasJSChart: any;
@Component({
    selector: 'user',
    templateUrl: './user.component.html'
})

export class UserComponent extends AppComponent {
    public userAccessDetail: Array<any>;
    public userFilterDetail: Array<any>;
    public eventAccess: any;
    public users: any;
    public user: any;
    public filters: Array<any>;
    public filterType: any;
    public filterTypes: Array<any>;
    public roles: Array<any>;
    public access: any;
    public interfaces: Array<any>;
    public interface: InterfaceModel;
    isEditInterface: boolean;
    isEditRole: boolean;
    public role: any;
    editRoleIndex: number;
    editInterfaceIndex: any;
    public isRole: boolean;
    public isInterface: boolean;
    public isAccess: boolean;
    public isFilter: boolean;
    constructor(protected commonService: CommonService, protected router: Router) {
        super(router, commonService);
        this.interface = new InterfaceModel();
        this.isEditInterface = false;
        this.isEditRole = false;
        this.editInterfaceIndex = -1;
        this.isRole = false;
        this.editRoleIndex = -1;
        this.isAccess = false;
        this.isFilter = false;
        this.isInterface = false;
        this.user = {};
        this.users = [];
        this.filters = [];
        this.filterType = {};
        this.filterTypes = [];
        this.roles = [];
        this.access = [];
        this.role = {};
        this.role.RoleID = 0;
        this.user.UserID = 0;
        this.filterType.FilterTypeID = 0;
        this.interfaces = [];
        this.userAccessDetail = [];
        this.userFilterDetail = [];
        this.eventAccess = {};
        this.clearInterfaceData();

        if (this.router.url.indexOf('role') > -1) {
            this.loadRoles(false);
            this.isRole = true;
        }
        else if (this.router.url.indexOf('interface') > -1) {
            this.loadInterfaces(false);
            this.isInterface = true;
        }
        else if (this.router.url.indexOf('access') > -1) {
            this.loadEventAccess();
            this.isAccess = true;
        }
        else if (this.router.url.indexOf('filter') > -1) {
            this.loadUsers();
            this.isFilter = true;
        }
    }
   
    ngOnInit() {
       
    }
    loadEventAccess() {
        var result = this.commonService.get('User/GetAllEventAccess').subscribe(
            response => {
                if (response) {
                    //this.eventAccess = response;
                    for (var i = 0; i < response.length; i++) {
                        var _eventName = response[i].eventAccessName;
                        var _eventID = response[i].eventAccessID;
                        //this.eventAccess.push({ _eventName: _eventID });
                        this.eventAccess[_eventName] = _eventID;
                    }
                    this.loadRoles(true);
                } else {
                    // this.router.navigate(['/home']);
                }
            },
            error => {
                //dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
            });
        return result;
    }
    loadInterfaces(isAccess: boolean) {
        var result = this.commonService.get('User/GetAllInterfaces').subscribe(
            response => {
                if (response) {
                    this.interfaces = response;
                    if (isAccess) {
                        this.role.RoleID = this.roles[0].userRoleID;
                        this.loadUserAccess(this.role.RoleID);
                    }
                    else {
                        dpJs.loadInterfaces(response);
                    }
                   
                } else {
                    // this.router.navigate(['/home']);
                }
            },
            error => {
                //dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
            });
        return result;
    }
    
    loadRoles(isAccess: boolean) {
        var result = this.commonService.get('User/GetAllRoles').subscribe(
            response => {
                if (response) {
                    this.roles = response;
                    if (isAccess) {
                        if (this.roles.length > 0) {
                            this.loadInterfaces(isAccess);
                        }
                    }
                    else {
                        dpJs.loadRoles(response);
                    }
                } else {
                    // this.router.navigate(['/home']);
                }
            },
            error => {
                //dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
            });
        return result;
    }
    loadUsers() {
        var result = this.commonService.get('User/GetAllUsers').subscribe(
            response => {
                if (response) {
                    this.users = response;
                    this.loadFilterTypes();
                } else {
                    // this.router.navigate(['/home']);
                }
            },
            error => {
                //dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
            });
        return result;
    }
    loadFilterTypes() {
        var result = this.commonService.get('User/GetAllFilterTypes').subscribe(
            response => {
                if (response) {
                    this.filterTypes = response;
                    this.loadUserFilters();
                    
                } else {
                    // this.router.navigate(['/home']);
                }
            },
            error => {
               // dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
            });
        return result;
    }
    loadUserAccess(roleID: number) {
        if (roleID > 0) {
            var result = this.commonService.get('User/GetUserAccessByRoleID?RoleID=' + roleID).subscribe(
                response => {
                    if (response) {
                        this.userAccessDetail = response;
                        dpJs.drawInterfaceTable(this.interfaces, roleID, this.eventAccess, this.userAccessDetail);
                    } else {
                        // this.router.navigate(['/home']);
                    }
                },
                error => {
                    //dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
                });
            return result;
        }
        
        
    }
    loadUserFilters() {
        if (this.user.UserID != 0 && this.filterType.FilterTypeID != 0) {
            var result = this.commonService.get('User/GetUserFilter?UserID=' + this.user.UserID + '&FilterTypeID=' + this.filterType.FilterTypeID).subscribe(
                response => {
                    if (response) {
                        let _userFilterDetail: Array<any> = response.userFilterDetail;
                        this.filters = response.filters;
                        //var test = response.userFilterDetail.json()['FilterTypeValue'];
                        //response.userFilterDetail.map()
                        _userFilterDetail.forEach(obj => {
                            this.userFilterDetail.push(obj.FilterTypeValue);
                        });
                        for (var i = 0; i < this.filters.length; i++) {
                            if (this.userFilterDetail.indexOf(this.filters[i].FilterTypeValue) > -1) {
                                this.filters[i].IsChecked = true;
                            }
                        }
                        dpJs.loadUserFilters(this.filters);
                        //dpJs.drawInterfaceTable(this.interfaces, roleID, this.eventAccess, this.userAccessDetail);
                    } else {
                        // this.router.navigate(['/home']);
                    }
                },
                error => {
                    //dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
                });
            $('#tblUserFilter').DataTable();
            return result;
        }
    }
    //loadFilterByFilterType() {
    //    var result = this.commonService.get('User/GetFilterByFilterType?FilterTypeName=' +  this.user.FilterTypeName).subscribe(
    //        response => {
    //            if (response) {

    //                this.userFilterDetail = response.userFilterDetail;
    //                this.filters = response.filters;
    //                for (var i = 0; i < this.filters.length; i++) {
    //                    if (this.userFilterDetail.indexOf(this.filters[i].filterTypeValue) > -1) {
    //                        this.filters[i].isChecked = true;
    //                    }
    //                }
    //                //dpJs.drawInterfaceTable(this.interfaces, roleID, this.eventAccess, this.userAccessDetail);
    //            } else {
    //                // this.router.navigate(['/home']);
    //            }
    //        },
    //        error => {
    //            dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
    //        });
    //    return result;
    //}
    setUserAccessByRole() {
       // this.role.UserRoleID = roleId;
        //this.selectedUserRoleName = Name;
        this.loadUserAccess(this.role.RoleID);
    }
    //$scope.setParentInterface = function (ID, Name) {
    //    $scope.interface.ParentInterfaceID = ID;
    //    $scope.selectedParentInterfaceName = Name;
    //}

    updateUserAccess() {
        //var _userAccess = new Array();
        this.commonService.post('User/CreateUserAccess', this.userAccessDetail).subscribe(
            response => {
                if (response) {
                    if (response = true) {
                        dpJs.addNotification('success', 'User Access updated Successfully!', 'success');
                        this.loadUserAccess(this.role.RoleID);
                    }
                    else  {
                        dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
                    }
                }
            },
            error => {
                //dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
            });
    }
    
    updateFilter() {
        //var _userAccess = new Array();
        this.commonService.post('User/CreateUserFilter',this.userFilterDetail).subscribe(
            response => {
                if (response) {
                    if (response = true) {
                        dpJs.addNotification('success', 'User Filter updated Successfully!', 'success');
                        this.loadUserAccess(this.role.RoleID);
                    }
                    else {
                        dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
                    }
                }
            },
            error => {
                //dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
            });
    }
    switchCheckedFilter(element: string)
    {

    }
    setFilterCheckbox() {
        if (document.getElementById('btnSwitchCheckedFilter') !== null) {
            var checkbox: any = document.getElementById('btnSwitchCheckedFilter');
            if (checkbox.getAttribute("ischecked") == 'true') {
                this.userFilterDetail.push({
                    'FilterTypeID': this.filterType.FilterTypeID,
                    'FilterTypeValue': checkbox.getAttribute("filterTypeValue"),
                    'UserID': this.user.UserID
                });
                //filter.IsChecked = true;
            }
            else {
                //filter.IsChecked = false;
                var _index = this.userFilterDetail.findIndex(u => u == checkbox.getAttribute("filterTypeValue"));
                this.userFilterDetail.splice(_index, 1);
            }
        }
    }
    CheckboxChecked() {
        if (document.getElementById('btnSwitchChecked') !== null) {
            var checkbox: any = document.getElementById('btnSwitchChecked');
            if (checkbox.getAttribute("checked") == 'checked') {
                this.userAccessDetail.push({
                    'userRoleID': this.role.RoleID,
                    'filterTypeValue': checkbox.getAttribute("interfaceId"),
                    'eventAccessID': checkbox.getAttribute("eventaccess")
                });
               // $(this).addClass('checked');
            }
            else {
               // $(this).removeClass('checked');
                this.removeUserAccess(checkbox.getAttribute("interfaceId"), checkbox.getAttribute("eventaccess"));
            }
        }
    }
    switchChecked(elm: string) {
        this.userAccessDetail = dpJs.switchChecked(elm, this.role.RoleID, this.userAccessDetail);
    }
    addRole(addRoleForm: NgForm) {
        var RoleName = addRoleForm.form.value.roleName;
        var RoleRemarks = addRoleForm.form.value.RoleRemarks;
        if (RoleName != undefined) {
            var _role = { UserRoleName: RoleName, Remarks: RoleRemarks, UserRoleID: this.role.RoleID };
            var result = this.commonService.post('User/AddEditRole', _role).subscribe(
                response => {
                    if (response) {
                        if (response != undefined) {
                            if (this.role.RoleID == 0) {
                                dpJs.addNotification('success', 'Role Added Successfully!', 'success');
                            }
                            else {
                                dpJs.addNotification('success', 'Role Updated Successfully!', 'success');
                            }
                            this.role = {};
                            this.loadRoles(false);
                        }
                    }
                },
                error => {
                    //dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
                });
        }
    }
    editRole() {
        if (document.getElementById('hdnRoleID') !== null) {
            var roleID: any = document.getElementById('hdnRoleID');
            var _role = this.roles.filter(i => i.userRoleID == parseInt(roleID.value));
            if (_role != undefined) {
                this.role.RoleID = _role[0].userRoleID;
                this.role.RoleName = _role[0].userRoleName;
                this.role.Remarks = _role[0].remarks;
                this.isEditRole = true;
            }
        }
    }
    deleteRole() {
        if (confirm('Are sure to Delete?')) {
            if (document.getElementById('hdnRoleID') !== null) {
                var roleID: any = document.getElementById('hdnRoleID');
                var result = this.commonService.post('User/DeleteRole', roleID.value).subscribe(
                    response => {
                        if (response) {
                            if (response != undefined) {
                                dpJs.addNotification('success', 'Role Deleted Successfully!', 'success');
                                this.role = {};
                                this.loadRoles(false);
                            }
                        }
                    },
                    error => {
                        //dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
                    });
            }
        }
    }
    addInterface(addInterfaceForm: NgForm) {
        var InterfaceName = addInterfaceForm.form.value.interfaceName;
        var ParentInterfaceID = addInterfaceForm.form.value.parentInterfaceID;
        var Remarks = addInterfaceForm.form.value.interfaceRemarks;
        if (InterfaceName != undefined) {
            this.interface.InterfaceName = InterfaceName;
            this.interface.ParentInterfaceID = this.interface.ParentInterfaceID;
            var result = this.commonService.post('User/AddEditInterface',this.interface).subscribe(
                response => {
                    if (response) {
                        if (response != undefined) {
                            if (this.interface.InterfaceID == 0) {
                                dpJs.addNotification('success', 'Interface Added Successfully!', 'success');
                            }
                            else {
                                dpJs.addNotification('success', 'Interface Updated Successfully!', 'success');
                            }
                            this.clearInterfaceData();
                            this.loadInterfaces(false);
                        }
                    }
                },
                error => {
                    //dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
                });
        }
    }
    editInterface() {
        if (document.getElementById('hdnInterfaceID') !== null) {
            var interfaceID: any = document.getElementById('hdnInterfaceID');
            var _interface = this.interfaces.filter(i => i.interfaceID == parseInt(interfaceID.value));
            if (_interface != undefined) {
                this.interface.InterfaceID = _interface[0].interfaceID;
                this.interface.InterfaceName = _interface[0].interfaceName;
                this.interface.ParentInterfaceID = _interface[0].parentInterfaceID;
                this.interface.Remarks = _interface[0].remarks;
                this.isEditInterface = true;
            }
        }
    }
    deleteInterface() {
        if (confirm('Are sure to Delete?')) {
            if (document.getElementById('hdnInterfaceID') !== null) {
                var interfaceID: any = document.getElementById('hdnInterfaceID');
                var result = this.commonService.post('User/DeleteInterface', interfaceID.value).subscribe(
                    response => {
                        if (response) {
                            if (response != undefined) {
                                dpJs.addNotification('success', 'Interface Deleted Successfully!', 'success');
                                this.clearInterfaceData();
                                this.loadInterfaces(false);
                            }
                        }
                    },
                    error => {
                        //dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
                    });
            }
        }
    }
    private clearInterfaceData() {
        this.interface = new InterfaceModel();
        this.isEditInterface = false;
        this.interface.ParentInterfaceID = 0;
    }
    private removeUserAccess(interfaceId: number,eventaccess:number) {
        for (var i = 0; i < this.userAccessDetail.length; i++) {
            if (this.userAccessDetail[i].filterTypeValue == interfaceId && this.userAccessDetail[i].eventAccessID == eventaccess) {
                this.userAccessDetail.splice(i, 1);
                break;
            }
        }
    }
    //private getInterfacesWithoutParent() {
    //$scope.interfacesWithoutParent = new Array();
    //for (var i = 0; i < $scope.interfaces.length; i++) {
    //    if ($scope.interfaces[i].ParentInterfaceID == 0) {
    //        $scope.interfacesWithoutParent.push($scope.interfaces[i]);
    //    }
    //}

}
