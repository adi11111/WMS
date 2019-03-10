var dpJs = (function () {
    return {
        loadPolicies: function (policies) {
                if ($.fn.dataTable.isDataTable('#tblPolicy')) {
                    $('#tblPolicy').DataTable().destroy();
                }
                $('#tblPolicy').DataTable({
                    data: policies,
                    "order": [[1, "asc"]],
                    "columns": [
                        { "data": "InputCode" },
                        { "data": "PolicyNo" },
                        { "data": "VINo" },
                        { "data": "InvoiceNo" },
                        { "data": "SubGroupName" },
                        { "data": "PolicyStartDate" },
                        { "data": "PolicyExpiryDate" },
                        { "data": "DealerName" },
                        { "data": "CustomerName" },
                        { "data": "Make" },
                        { "data": "Model" },
                        { "data": "PolicyStatusCode" }
                    ],
                    "columnDefs": [
                        {
                            "render": function (data, type, row) {
                                return '<a href="javascript:void(0)" [routerLink]="[\' / processclaim?policyno='+data+'\']">' + data + '</i>';
                            },
                            "targets": 1
                        },
                         { className: "hide_column", "targets": [0] },
                        {
                            "render": function (data, type, row) {
                                return data;
                            },
                            "targets": 5
                        },
                        {
                            "render": function (data, type, row) {
                                return data;
                            },
                            "targets": 6
                        },
                        {
                            "render": function (data, type, row) {
                                if (data == 5) {
                                    return 'Expired';
                                } else {
                                    return 'Invoiced';
                                }
                            },
                            "targets": 10
                        }
                    ],
                    "rowCallback": function (row, data) {
                    }
                });
        },
        loadAllPolicies: function (policies) {
            if ($.fn.dataTable.isDataTable('#tblPolicies')) {
                $('#tblPolicies').DataTable().destroy();
            }
            $('#tblPolicies').DataTable({
                data: policies,
                "order": [[1, "dsc"]],
                "columns": [
                    { "data": "SINum" },
                    { "data": "PolNumber" },
                    { "data": "UINumber" },
                    { "data": "ProductGroup" },
                    { "data": "ProductSubGroupName" },
                    { "data": "StartDate" },
                    { "data": "ExpiryDate" },
                    { "data": "DealerName" },
                    { "data": "CustomerName" },
                    { "data": "MakeName" },
                    { "data": "ModelName" },
                    { "data": "Status" }
                ],
                "columnDefs": [
                    {
                        "render": function (data, type, row) {
                            return '<a href="javascript:void(0)" class="fa fa-edit"></i> / <a href="http://localhost:25194/home/showreport?Name=PC82_new&InvoiceNumber=' + row.PolNumber +'" target="_blank" class="fa fa-file hidden"> </a>';
                        },
                        "targets": 0
                    },
                    // { className: "hide_column", "targets": [0] },
                    {
                        "render": function (data, type, row) {
                            return data.split('T')[0];
                        },
                        "targets": 5
                    },
                    {
                        "render": function (data, type, row) {
                            return data.split('T')[0];
                        },
                        "targets": 6
                    },
                    {
                        "render": function (data, type, row) {
                            if (data == 0) {
                                return 'Approved';
                            }
                            else if (data == 12) {
                                return 'Rejected';
                            }
                            else if (data == 24) {
                                return 'Authorized';
                            }
                            else if (data == 48) {
                                return 'Cancelled';
                            }
                        },
                        "targets": 11
                    }
                ],
                "rowCallback": function (row, data) {
                }
            });
        },
        loadClaimByPolicyNum: function (claims) {
            if ($.fn.dataTable.isDataTable('#tblClaimByPolicyNum')) {
                $('#tblClaimByPolicyNum').DataTable().destroy();
            }
            $('#tblClaimByPolicyNum').DataTable({
                data: claims,
                "order": [[1, "asc"]],
                "columns": [
                    { "data": "ClaimCode" },
                    { "data": "ClaimNo" },
                    { "data": "ClaimReceivedDate" },
                    { "data": "WorkshopName" },
                    { "data": "DealerName" },
                    { "data": "SubGroupName" },
                    { "data": "Make" },
                    { "data": "Model" },
                    { "data": "FaultName" },
                    { "data": "LastService" },
                    { "data": "RequestedAmount" },
                    { "data": "PartsCost" },
                    { "data": "AuthorisedAmount" },
                    { "data": "PaidAmount" },
                    { "data": "PayeeName" }
                ],
                "columnDefs": [
                    {
                        "render": function (data, type, row) {
                            return '<input type="button" class="btn btn-primary edit-claim" data-claimcode="'+ data +'"  value="Edit" /><span class="btn btn-danger delete-claim" (click)="editClaimForm(' + data + ');$event.stopPropagation();">Edit</span>';
                        },
                        "targets": 0
                    },
                ],
                "rowCallback": function (row, data) {
                }
            });
        },
        loadInterfaces: function (interfaces) {
            if ($.fn.dataTable.isDataTable('#tblInterface')) {
                $('#tblInterface').DataTable().destroy();
            }
            $('#tblInterface').DataTable({
                data: interfaces,
                "order": [[1, "asc"]],
                "columns": [
                    { "data": "interfaceID" },
                    { "data": "interfaceName" },
                    { "data": "parentInterfaceID" },
                    { "data": "remarks" }
                ],
                "columnDefs": [
                    {
                        "render": function (data, type, row) {
                            return '<input type="button" class="btn btn-primary delete-interface" data-interfaceid="' + data + '"  value="Delete" /> <span class="btn btn-danger  edit-interface" (click)="editInterface(' + data + ');$event.stopPropagation();"  data-interfaceid="' + data + '" >Edit</span>';
                        },
                        "targets": 0
                    },
                    {
                        "render": function (data, type, row) {
                            if (data == 0) {
                                return ' -';
                            }
                            else {
                                return dpJs.getInterfaceById(data, interfaces);
                            }
                        },
                        "targets": 2
                    }
                ],
                "rowCallback": function (row, data) {
                }
            });
            
        },
        getInterfaceById: function(Id,interfaces) {
            var _interfaceName = '-';
            for (var i = 0; i < interfaces.length; i++) {
                if (interfaces[i].interfaceID === Id) {
                    _interfaceName = interfaces[i].interfaceName
                    break;
                }
            }
            return _interfaceName;
        },
        getAllParentInterfaces: function(interfaces) {
            var _parentInterfaces = new Array();
            for (var i = 0; i < interfaces.length; i++) {
                if (interfaces[i].parentInterfaceID != 0) {
                    if (_parentInterfaces.indexOf(interfaces[i].parentInterfaceID) == -1) {
                        _parentInterfaces.push(interfaces[i].parentInterfaceID);
                    }
                }
            }
            return _parentInterfaces;
        },
        loadRoles: function (claims) {
            if ($.fn.dataTable.isDataTable('#tblRole')) {
                $('#tblRole').DataTable().destroy();
            }
            $('#tblRole').DataTable({
                data: claims,
                "order": [[1, "asc"]],
                "columns": [
                    { "data": "userRoleID" },
                    { "data": "userRoleName" },
                    { "data": "remarks" }
                ],
                "columnDefs": [
                    {
                        "render": function (data, type, row) {
                            return '<input type="button" class="btn btn-primary delete-role" data-roleid="' + data + '"  value="Delete" /> <span class="btn btn-danger edit-role" (click)="editRole(' + data + ');$event.stopPropagation();" data-roleid="' + data + '"   >Edit</span>';
                        },
                        "targets": 0
                    },
                ],
                "rowCallback": function (row, data) {
                }
            });
        },
        loadUserFilters: function (filters) {
            if ($.fn.dataTable.isDataTable('#tblUserFilter')) {
                $('#tblUserFilter').DataTable().destroy();
            }
            $('#tblUserFilter').DataTable({
                data: filters,
                "order": [[1, "asc"]],
                "columns": [
                    { "data": "FilterTypeValue" },
                    { "data": "IsChecked" },
                    { "data": "FilterName" }
                ],
                "columnDefs": [
                    {
                        "render": function (data, type, row) {
                            var checked = "";
                            if (data == true) {
                                checked = "checked='checked'";
                            }
                            return ' <div class="icheckbox_flat-blue checkbox-container"><input  type="checkbox" ' + checked + ' class="flat" /> <ins class="iCheck-helper"></ins></div>';
                        },
                        "targets": 1
                    },
                    { className: "hide_column", "targets": [0] },
                    {
                        "render": function (data, type, row) {
                            return data;
                        },
                        "targets": 2
                    }
                ],
                "rowCallback": function (row, data) {
                }
            });
        },
        drawInterfaceTable: function (interfaces, UserRoleID, userEvents, userAccesses) {
            function getUserAccessEventsByInterfaceId(interfaceId) {
                var _userAccessEvent = new Array;
                for (var i = 0; i < userAccesses.length; i++) {
                    if (userAccesses[i].filterTypeValue == interfaceId) {
                        _userAccessEvent.push(userAccesses[i].eventAccessID);
                    }
                }
                return _userAccessEvent;
            }
            var _tbody = $('#tblUserAccess tbody');
            var userAccessDetail = new Array();
            $('#tblUserAccess tbody').html('');
            if ($.fn.dataTable.isDataTable('#tblUserAccess')) {
                $('#tblUserAccess').DataTable().clear();
                $('#tblUserAccess').DataTable().destroy();
            }
            //var _parentInterfaces = this.getAllParentInterfaces(interfaces);
            var _totalAdd = 0;
            var _totalEdit = 0;
            var _totalDelete = 0;
            var _totalView = 0;
            var _totalReport = 0;
            for (var i = 0; i < interfaces.length; i++) {
                //if (_parentInterfaces.indexOf(interfaces[i].interfaceID) == -1) {
                    var isAllowAdd = '';
                    var isAllowEdit = '';
                    var isAllowDelete = '';
                    var isAllowView = '';
                    var isAllowReport = '';
                    var _userAccessEvents = getUserAccessEventsByInterfaceId(interfaces[i].interfaceID);
                    if (_userAccessEvents.indexOf(userEvents.AllowAdd) > -1) {
                        userAccessDetail.push({
                            'UserRoleID': UserRoleID,
                            'FilterTypeValue': interfaces[i].interfaceID,
                            'EventAccessID': userEvents.AllowAdd
                        });
                        _totalAdd++;
                        isAllowAdd = 'checked="checked"';
                    }
                    if (_userAccessEvents.indexOf(userEvents.AllowEdit) > -1) {
                        userAccessDetail.push({
                            'UserRoleID': UserRoleID,
                            'FilterTypeValue': interfaces[i].interfaceID,
                            'EventAccessID': userEvents.AllowEdit
                        });
                        _totalEdit++;
                        isAllowEdit = 'checked="checked"';
                    }
                    if (_userAccessEvents.indexOf(userEvents.AllowDelete) > -1) {
                        userAccessDetail.push({
                            'UserRoleID': UserRoleID,
                            'FilterTypeValue': interfaces[i].interfaceID,
                            'EventAccessID': userEvents.AllowDelete
                        });
                        _totalDelete++;
                        isAllowDelete = 'checked="checked"';
                    }
                    if (_userAccessEvents.indexOf(userEvents.AllowView) > -1) {
                        userAccessDetail.push({
                            'UserRoleID': UserRoleID,
                            'FilterTypeValue': interfaces[i].interfaceID,
                            'EventAccessID': userEvents.AllowView
                        });
                        _totalView++;
                        isAllowView = 'checked="checked"';
                    }
                    if (_userAccessEvents.indexOf(userEvents.AllowReport) > -1) {
                        userAccessDetail.push({
                            'UserRoleID': UserRoleID,
                            'FilterTypeValue': interfaces[i].interfaceID,
                            'EventAccessID': userEvents.AllowReport
                        });
                        _totalReport++;
                        isAllowReport = 'checked="checked"';
                    }
                    var _tr = '<tr><td>' + interfaces[i].interfaceID + '</td><td data-interfaceid="' + interfaces[i].interfaceID + '">' + this.getInterfaceById(interfaces[i].parentInterfaceID, interfaces) +
                        '</td><td> ' + this.getInterfaceById(interfaces[i].interfaceID, interfaces) + '</td>' +
                        '<td><div class="icheckbox_flat-blue checkbox-container ' + isAllowAdd.split('=')[0] + ' "> <input type="checkbox" ' + isAllowAdd + ' value="' + userEvents.AllowAdd + '" class="flat"  /> <span class="checkmark"></span></div> </td>' +
                        '<td><div class="icheckbox_flat-blue checkbox-container ' + isAllowEdit.split('=')[0] + ' "> <input type="checkbox" ' + isAllowEdit + ' value="' + userEvents.AllowEdit + '"   class="flat"  /> <span class="checkmark"></span></div> </td>' +
                        '<td><div class="icheckbox_flat-blue checkbox-container ' + isAllowDelete.split('=')[0] + ' ">  <input type="checkbox" ' + isAllowDelete + ' value="' + userEvents.AllowDelete + '"   class="flat"  /> <span class="checkmark"></span></div> </td>' +
                        '<td><div class="icheckbox_flat-blue checkbox-container ' + isAllowView.split('=')[0] + ' "> <input type="checkbox" ' + isAllowView + ' value="' + userEvents.AllowView + '"   class="flat"  /> <span class="checkmark"></span></div> </td>' +
                        '<td><div class="icheckbox_flat-blue checkbox-container ' + isAllowReport.split('=')[0] + ' ">  <input type="checkbox" ' + isAllowReport + ' value="' + userEvents.AllowReport + '"  class="flat"  /> <span class="checkmark"></span></div> </td>' +
                        '</tr>'
                    _tbody.append(_tr);
                //}
            }
                var _totalRecords = $('#tblUserAccess tbody tr').length;
            if (_totalAdd == _totalRecords) {
                $('#chkAllowAddAll').parent('div').addClass('checked');
                $('#chkAllowAddAll').prop('checked', true);
            }
            else {
                $('#chkAllowAddAll').prop('checked', false);
            }
                if (_totalEdit == _totalRecords) {
                    $('#chkAllowEditAll').parent('div').addClass('checked');
                    $('#chkAllowEditAll').prop('checked', true);
                }
                else {
                    $('#chkAllowEditAll').prop('checked', false);
                }
                if (_totalDelete == _totalRecords) {
                    $('#chkAllowDeleteAll').parent('div').addClass('checked');
                    $('#chkAllowDeleteAll').prop('checked', true);
                }
                else {
                    $('#chkAllowDeleteAll').prop('checked', false);
                }
                if (_totalView == _totalRecords) {
                    $('#chkAllowViewAll').parent('div').addClass('checked');
                    $('#chkAllowViewAll').prop('checked', true);
                }
                else {
                    $('#chkAllowViewAll').prop('checked', false);
                }
                if (_totalReport == _totalRecords) {
                    $('#chkAllowReportAll').parent('div').addClass('checked');
                    $('#chkAllowReportAll').prop('checked', true);
                }
                else {
                    $('#chkAllowReportAll').prop('checked', false);
                }
                $('#tblUserAccess').DataTable({
                    "order": [[0, "asc"]],
                    "columnDefs": [
                        { "visible": false, "targets": 0 }
                    ]
                });
                return userAccessDetail;
        },
        switchChecked: function (elm, UserRoleID, userAccessDetail) {
            var _checkbox = $('#' + elm);//.find('input[type="checkbox"]');
            //var userAccessDetail = new Array();
            var index = _checkbox.parents('th').index() + 1;
            var checked = _checkbox.is(':checked');
            var table = $('#tblUserAccess').DataTable();
            if (checked) {
                _checkbox.prop('checked', false);
               
            }
            else {
                _checkbox.prop('checked',true);
            }
            table.rows().every(function (rowIdx, tableLoop, rowLoop) {
                var data = this.data();
                var _value = $(data[index]).find('input[type="checkbox"]')[0].value;
                for (var i = 0; i < userAccessDetail.length; i++) {
                    if (userAccessDetail[i].eventAccessID == _value) {
                        userAccessDetail.splice(i, 1);
                        break;
                    }
                }
            });
            table.rows().every(function (rowIdx, tableLoop, rowLoop) {
                var data = this.data();
                var _checkbox = $(data[index]).find('input[type="checkbox"]');
                var _value = _checkbox[0].value;
                if (checked) {
                    data[index] = '<div class="icheckbox_flat-blue checkbox-container"> <input type="checkbox" value="' + _value + '"  class="flat" /> <span class="checkmark"></span></div>';
                    for (var i = 0; i < userAccessDetail.length; i++) {
                        if (userAccessDetail[i].eventAccessID == _value) {
                            userAccessDetail.splice(i, 1);
                            break;
                        }
                    }
                }
                else {
                    data[index] = '<div class="icheckbox_flat-blue checkbox-container checked"> <input type="checkbox" checked="checked" value="' + _value + '"  class="flat" /> <span class="checkmark"></span></div>';
                    //if (!_checkbox.is(':checked')) {
                        userAccessDetail.push({
                            'userRoleID': UserRoleID,
                            'filterTypeValue': data[0],
                            'eventAccessID': _value
                        });
                   // }
                    
                }
                this.data(data);
            });

            return userAccessDetail;
        },
        removeUserAccess: function (interfaceId, userAccessDetail) {
            for (var i = 0; i < userAccessDetail.length; i++) {
                if (userAccessDetail[i].InterfaceID == interfaceId) {
                    userAccessDetail.splice(i, 1);
                    break;
                }
            }
        },
        removeUserAccessByEvent: function (event, userAccessDetail) {
            for (var i = 0; i < userAccessDetail.length; i++) {
                if (userAccessDetail[i].EventAccess == event) {
                    userAccessDetail.splice(i, 1);
                    break;
                }
            }
        },
        post: function (url, files,headers) {
            return $.ajax({
                url: url,
                headers : headers,
                 //beforeSend: function(request) {
                 //    request.setRequestHeader({ 'Authorization': headers.Authorization });
                 //    request.setRequestHeader('ConfigId', headers.configId);
                 //    reqest.setRequestHeaer('programCode', headers.programCode);
                 // },
                data: files,
                cache: false,
                contentType: false,
                processData: false,
                method: 'POST',
                success: function (data) {
                }
            });
        },
        isLoginPage : function (isLogin) {
            if (isLogin) {
                $('.non-login').addClass('hidden');
            }
            else {
                $('.non-login').removeClass('hidden');
            }
        },
        monthNames: function (month) {
            var _monthNames = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
            if (month != undefined) return _monthNames[month];
            return _monthNames;
        },
        drawPolicyGraph: function (policies) {
            var _data = new Array();
            for (var i = 0; i < policies.length; i++) {
                _data.push({ y: policies[i].month, Policies: policies[i].policies });
            }
            var config = {
			    type: 'line',
			    data: {
				    labels: policies.map(l=>l.month),
				    datasets: [{
					    label: 'Policies Data',
                        backgroundColor: 'rgba(60, 141, 188, 0.52)',
                        borderColor: 'rgba(60, 141, 188, 1)',
                        pointStyle: 'rectRot',                        intRadius: 5,
						pointBorderColor: 'rgb(0, 0, 0)',
					    data: policies.map(d=>d.policies),
					    //fill: false,
				    //}, {
				    //	label: 'My Second dataset',
				    //	fill: false,
				    //	backgroundColor: window.chartColors.blue,
				    //	borderColor: window.chartColors.blue,
				    //	data: [
				    //		randomScalingFactor(),
				    //		randomScalingFactor(),
				    //		randomScalingFactor(),
				    //		randomScalingFactor(),
				    //		randomScalingFactor(),
				    //		randomScalingFactor(),
				    //		randomScalingFactor()
				    //	],
				    }]
                },
                	options: {
					responsive: true,
					legend: {
						labels: {
							usePointStyle: false
						}
					},
					scales: {
						xAxes: [{
							display: true,
							scaleLabel: {
								display: true,
								labelString: 'Month'
							}
						}],
						yAxes: [{
							display: true,
							scaleLabel: {
								display: true,
								labelString: 'Value'
							}
						}]
					},
					title: {
						display: true,
						text: 'Total Policies In One Past Year'
					}
				}
			    //options: {
				   // responsive: true,
				   // title: {
					  //  display: true,
					  //  text: 'Chart.js Line Chart'
				   // },
				   // tooltips: {
					  //  mode: 'index',
					  //  intersect: false,
				   // },
				   // hover: {
					  //  mode: 'nearest',
					  //  intersect: true
				   // },
				   // scales: {
					  //  xAxes: [{
						 //   display: true,
						 //   scaleLabel: {
							//    display: true,
							//    labelString: 'Month'
						 //   }
					  //  }],
					  //  yAxes: [{
						 //   display: true,
						 //   scaleLabel: {
							//    display: true,
							//    labelString: 'Value'
						 //   }
					  //  }]
				   // }
			    //}
		    };
            var ctx = document.getElementById('chrtPolicies').getContext('2d');
            new Chart(ctx, config);
        },
        drawClaimGraph: function (claims) {
            var _data = new Array();
            for (var i = 0; i < claims.length; i++) {
                _data.push({ y: claims[i].month, 'Claims': claims[i].policies });
            }
            var color = Chart.helpers.color;
            var barChartData = {
                labels: claims.map(d => d.month),
			    datasets: [{
				    label: 'Claims Data',
                    backgroundColor: 'rgba(60, 141, 188, 0.52)',
                    borderColor: 'rgba(60, 141, 188, 1)',
				    borderWidth: 1,
				    data: claims.map(d=>d.claims)
			    //}, {
				   // label: 'Dataset 2',
				   // backgroundColor: color(window.chartColors.blue).alpha(0.5).rgbS tring(),
				   // borderColor: window.chartColors.blue,
				   // borderWidth: 1,
				   // data: [
					  //  randomScalingFactor(),
					  //  randomScalingFactor(),
					  //  randomScalingFactor(),
					  //  randomScalingFactor(),
					  //  randomScalingFactor(),
					  //  randomScalingFactor(),
					  //  randomScalingFactor()
				   // ]
			    }]

            };
            var ctx = document.getElementById('chrtClaims' ).getContext('2d');
			new Chart(ctx, {
				type: 'bar',
				data: barChartData,
				options: {
					responsive: true,
					legend: {
						position: 'top',
					},
					title: {
						display: true,
						text: 'Total Claims In Past One Year'
					}
				}
			});


        },
        drawPieChart: function (models,faults) {
            var randomScalingFactor = function () {
                return Math.round(Math.random() * 100);
            };
            var config = {
                type: 'doughnut',
                data: {
                    datasets: [{
                        data: models.map(d=>d.BurnRatio),
                        backgroundColor: [
                            'red',
                            'orange',
                            'yellow',
                            'green',
                            'blue',
                            'brown',
                            'purple',
                            'indigo',
                            'gray',
                            'violet',
                        ],
                        label: 'Dataset 1'
                    }],
                    labels: models.map(d => d.Model)
                },
                options: {
                    responsive: true,
                    legend: {
                        position: 'top',
                    },
                    title: {
                        display: true,
                        text: 'Most Burning Models'
                    },
                    animation: {
                        animateScale: true,
                        animateRotate: true
                    }
                }
            };
            var ctx = document.getElementById('pcModels').getContext('2d');
            new Chart(ctx, config);
            config = {
                type: 'doughnut',
                data: {
                    datasets: [{
                        data: faults.map(d => d.PartCost),
                        backgroundColor: [
                            'red',
                            'orange',
                            'yellow',
                            'green',
                            'blue',
                            'brown',
                            'purple',
                            'indigo',
                            'gray',
                            'violet',
                        ],
                        label: 'Dataset 1'
                    }],
                    labels: faults.map(l => l.FaultShortCode)
                },
                options: {
                    responsive: true,
                    legend: {
                        position: 'top',
                    },
                    title: {
                        display: true,
                        text: 'Most Burning Faults'
                    },
                    animation: {
                        animateScale: true,
                        animateRotate: true
                    }
                }
            };
            ctx = document.getElementById('pcFaults').getContext('2d');
            new Chart(ctx, config);

             











            Chart.defaults.doughnutLabels = Chart.helpers.clone(Chart.defaults.doughnut);

            var helpers = Chart.helpers;
            var defaults = Chart.defaults;

            Chart.controllers.doughnutLabels = Chart.controllers.doughnut.extend({
                updateElement: function (arc, index, reset) {
                    var _this = this;
                    var chart = _this.chart,
                        chartArea = chart.chartArea,
                        opts = chart.options,
                        animationOpts = opts.animation,
                        arcOpts = opts.elements.arc,
                        centerX = (chartArea.left + chartArea.right) / 2,
                        centerY = (chartArea.top + chartArea.bottom) / 2,
                        startAngle = opts.rotation, // non reset case handled later
                        endAngle = opts.rotation, // non reset case handled later
                        dataset = _this.getDataset(),
                        circumference = reset && animationOpts.animateRotate ? 0 : arc.hidden ? 0 : _this.calculateCircumference(dataset.data[index]) * (opts.circumference / (2.0 * Math.PI)),
                        innerRadius = reset && animationOpts.animateScale ? 0 : _this.innerRadius,
                        outerRadius = reset && animationOpts.animateScale ? 0 : _this.outerRadius,
                        custom = arc.custom || {},
                        valueAtIndexOrDefault = helpers.getValueAtIndexOrDefault;

                    helpers.extend(arc, {
                        // Utility
                        _datasetIndex: _this.index,
                        _index: index,

                        // Desired view properties
                        _model: {
                            x: centerX + chart.offsetX,
                            y: centerY + chart.offsetY,
                            startAngle: startAngle,
                            endAngle: endAngle,
                            circumference: circumference,
                            outerRadius: outerRadius,
                            innerRadius: innerRadius,
                            label: valueAtIndexOrDefault(dataset.label, index, chart.data.labels[index])
                        },

                        draw: function () {
                            var ctx = this._chart.ctx,
                                vm = this._view,
                                sA = vm.startAngle,
                                eA = vm.endAngle,
                                opts = this._chart.config.options;

                            var labelPos = this.tooltipPosition();
                            var segmentLabel = vm.circumference / opts.circumference * 100;

                            ctx.beginPath();

                            ctx.arc(vm.x, vm.y, vm.outerRadius, sA, eA);
                            ctx.arc(vm.x, vm.y, vm.innerRadius, eA, sA, true);

                            ctx.closePath();
                            ctx.strokeStyle = vm.borderColor;
                            ctx.lineWidth = vm.borderWidth;

                            ctx.fillStyle = vm.backgroundColor;

                            ctx.fill();
                            ctx.lineJoin = 'bevel';

                            if (vm.borderWidth) {
                                ctx.stroke();
                            }

                            if (vm.circumference > 0.15) { // Trying to hide label when it doesn't fit in segment
                                ctx.beginPath();
                                ctx.font = helpers.fontString(opts.defaultFontSize, opts.defaultFontStyle, opts.defaultFontFamily);
                                ctx.fillStyle = "#fff";
                                ctx.textBaseline = "top";
                                ctx.textAlign = "center";

                                // Round percentage in a way that it always adds up to 100%
                                ctx.fillText(segmentLabel.toFixed(0) + "%", labelPos.x, labelPos.y);
                            }
                        }
                    });

                    var model = arc._model;
                    model.backgroundColor = custom.backgroundColor ? custom.backgroundColor : valueAtIndexOrDefault(dataset.backgroundColor, index, arcOpts.backgroundColor);
                    model.hoverBackgroundColor = custom.hoverBackgroundColor ? custom.hoverBackgroundColor : valueAtIndexOrDefault(dataset.hoverBackgroundColor, index, arcOpts.hoverBackgroundColor);
                    model.borderWidth = custom.borderWidth ? custom.borderWidth : valueAtIndexOrDefault(dataset.borderWidth, index, arcOpts.borderWidth);
                    model.borderColor = custom.borderColor ? custom.borderColor : valueAtIndexOrDefault(dataset.borderColor, index, arcOpts.borderColor);

                    // Set correct angles if not resetting
                    if (!reset || !animationOpts.animateRotate) {
                        if (index === 0) {
                            model.startAngle = opts.rotation;
                        } else {
                            model.startAngle = _this.getMeta().data[index - 1]._model.endAngle;
                        }

                        model.endAngle = model.startAngle + model.circumference;
                    }

                    arc.pivot();
                }
            });

            //ctx = document.getElementById('pcFaults').getContext('2d');
            //var myDoughnutChart = new Chart(ctx, {
            //    type: 'doughnut',
            //    data: data,
            //    options: {
            //        responsive: true,
            //        legend: {
            //            position: 'top',
            //        },
            //        title: {
            //            display: true,
            //            text: 'Most Burning Makes'
            //        },
            //        animation: {
            //            animateScale: true,
            //    animateRotate: true
            //        }
            //    }
            //});

        },
        formatDDmmYYYY: function (date) {
            if (typeof (date) != Date) {
                date = new Date(date);
            }
            var year = date.getFullYear();

            var month = (1 + date.getMonth()).toString();
            month = month.length > 1 ? month : '0' + month;

            var day = date.getDate().toString();
            day = day.length > 1 ? day : '0' + day;

            return day + '-' + month + '-' + year;
        },
        formatYYYYmmDD: function (date) {
            if (typeof (date) != Date) {
                date = new Date(date);
            }
            var year = date.getFullYear();

            var month = (1 + date.getMonth()).toString();
            month = month.length > 1 ? month : '0' + month;

            var day = date.getDate().toString();
            day = day.length > 1 ? day : '0' + day;

            return year + '-' + month + '-' + day;
        },
        addNotification: function (title, text, type) {
            new PNotify({
                title: title,
                text: text,
                type: type,
                styling: 'bootstrap3'
            });
        },
        modal : function(open,header,body){
            if(open){
                $('#dpModal .modal-title').text(header);
                $('#dpModal .modal-body p').text(body);
                $('#dpModal').modal('show');
            }
            else {
                $('.modal').modal('hide');  
                $('body').removeClass('modal-open');
                $('.modal-backdrop').remove();

            }
        },
        showpolicyPath: function () {
            return '/showpolicy';
        },
        reportPath: function () {
            return 'http://localhost:25194/home/showreport';
        }
    }
})(dpJs || {})
$(document).ready(function () {
    $('body,html').on('click', '#tblPolicy tbody tr', function (e) {
        e.stopImmediatePropagation();
        var data = $('#tblPolicy').DataTable().row(this).data();
        if (data != undefined) {
            $('#hdnPolicyNum').val(data.InputCode);
            $('#btnClaimByPolicyNo').click();
        }
    });
    $('body,html').on('click', '#tblPolicy tbody tr', function (e) {
        e.stopImmediatePropagation();
        var data = $('#tblPolicy').DataTable().row(this).data();
        if (data != undefined) {
            $('#hdnPolicyNum').val(data.InputCode);
            $('#btnClaimByPolicyNo').click();
        }
    });
    $('body,html').on('click', '#tblPolicy tbody tr', function (e) {
        e.stopImmediatePropagation();
        var data = $('#tblPolicy').DataTable().row(this).data();
        if (data != undefined) {
            $('#hdnPolicyNum').val(data.InputCode);
            $('#btnClaimByPolicyNo').click();
        }
    });
    $('body,html').on('click', '#tblPolicies tbody tr .fa-edit', function (e) {
        e.stopImmediatePropagation();
        var data = $('#tblPolicies').DataTable().row($(this).parents('tr')).data();
        if (data != undefined) {
            $('#hdnPolicyCode').val(data.SINum);
            $('#btnShowPolicy').click();
        }
    });
    $('body,html').on('click', '#tblInterface tr .edit-interface', function (e) {
        e.stopImmediatePropagation();
        var interfaceId = $(this).data('interfaceid');
        if (interfaceId != undefined) {
            $('#hdnInterfaceID').val(interfaceId);
            $('#btnEditInterface').click();
        }
    });
    $('body,html').on('click', '#tblInterface tr .delete-interface', function (e) {
        e.stopImmediatePropagation();
        var interfaceId = $(this).data('interfaceid');
        if (interfaceId != undefined) {
            $('#hdnInterfaceID').val(interfaceId);
            $('#btnDeleteInterface').click();
        }
    });
    $('body,html').on('click', '#tblRole tr .edit-role', function (e) {
        e.stopImmediatePropagation();
        var interfaceId = $(this).data('roleid');
        if (interfaceId != undefined) {
            $('#hdnRoleID').val(interfaceId);
            $('#btnEditRole').click();
        }
    });
    $('body,html').on('click', '#tblRole tr .delete-role', function (e) {
        e.stopImmediatePropagation();
        var interfaceId = $(this).data('roleid');
        if (interfaceId != undefined) {
            $('#hdnRoleID').val(interfaceId);
            $('#btnDeleteRole').click();
        }
    });
    $('body,html').on('click', '#tblClaimByPolicyNum tr .edit-claim', function (e) {
        e.stopImmediatePropagation();
        //var data = $('#tblClaimByPolicyNum').DataTable().row($(this).parents('tr')).data();
        var claimCode = $(this).data('claimcode');
        if (claimCode != undefined) {
            //$('#hdnPolicyNum').val(data.InputCode);
            $('#btnEditClaim').val(claimCode).click();
            //$('#btnEditClaim').click();
            //$(this).find('.edit-claim').click();
        }
    });
    $('body,html').on('click', '#tblUserAccess tbody tr .checkbox-container', function (e) {
        e.stopImmediatePropagation();
        var _checkbox = $(this).find('input[type="checkbox"]');
        var _interfaceId = _checkbox.parents('tr').find('td:first').data('interfaceid');
        if (_checkbox.is(':checked') == false) {
            _checkbox.prop('checked',true);
        }
        else {
            _checkbox.prop('checked', false);
        }
        $('#btnSwitchChecked').attr('checked', _checkbox.is(':checked')).attr('interfaceid', _interfaceId).attr('eventaccess', _checkbox.val()).click();
    });
    $('body,html').on('click', '#tblUserFilter tbody tr .checkbox-container', function (e) {
        e.stopImmediatePropagation();
        var _checkbox = $(this).find('input[type="checkbox"]');
        var _filterTypeValue = _checkbox.parents('tr').find('td:first').text();
        //if (_checkbox.is(':checked') == false) {
        //    $(this).addClass('checked');
        //}
        //else {
        //    $(this).removeClass('checked');
        //}
        $('#btnSwitchCheckedFilter').attr('ischecked', _checkbox[0].checked).attr('filtertypevalue', _filterTypeValue).click();
    });
});