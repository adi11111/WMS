using GwDealerPortal.DataAccess;
using GwDealerPortal.DataAccess.Entities;
using GwDealerPortal.DataAccess.Interfaces;
using GwDealerPortal.Model;
using GwDealerPortal.Service.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GwDealerPortal.Service.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {
            private IConfiguration _config;
            private IGenericRepository<User> _genericRepository;
            private IUnitOfWork _uow;

            public TokenController(IConfiguration config, IGenericRepository<User> genericRepository,IUnitOfWork _uow)
            {
                _config = config;
                _genericRepository = genericRepository;
                this._uow = _uow;
            }
            //[Route("api/LoginData")]
            [AllowAnonymous]
            [HttpGet("LoginData", Name = "GetLoginData")]
            public IActionResult GetLoginData()
            {
            //var data =  DbAccess.ExecuteQuery(DbAccess.DbWems,"select  * from PR_WEMS.dbo.WEMS_Program select * from PR_WEMS.dbo.WEMS_Config inner join WEMS_Location on WEMS_Location.LocationCode = WEMS_Config.LocationCode",new Dictionary<string, System.Data.SqlClient.SqlParameter>());
            var data = DbAccess.ExecuteQuery(DbAccess.DbWems, "select  * from PR_WEMSPORTAL.dbo.Program select * from  PR_WEMSPORTAL.dbo.Location ", new Dictionary<string, System.Data.SqlClient.SqlParameter>());
            List<ProgramModel> programs = data.Tables[0].ToList<ProgramModel>();
                List<LocationModel> locations = data.Tables[1].ToList<LocationModel>();
                return Json(new {Program = programs , Location = locations });
                //return Json(data);
            }

            [AllowAnonymous]
            [HttpPost]
            public IActionResult CreateToken([FromBody]LoginModel login)
            {
            try
            {
                IActionResult response = Unauthorized();
                var user = Authenticate(login);
                var _eventAccess = _uow.Repository<EventAccess>().Get();
                var _filters = _uow.Repository<Filter>().Get(f=>f.IsDeleted == false && f.UserRoleID == user.RoleCode);
                HttpContext.Session.Set("Filters", _filters);
                HttpContext.Session.Set("EventAccess", _eventAccess);

                
                if (user != null)
                {
                    login.UserId = user.UserCode;
                    login.RoleId = user.RoleCode;
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                    new Claim(JwtRegisteredClaimNames.NameId, user.UserCode.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Birthdate, user.Birthdate.ToString("yyyy-MM-dd")),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(540),
                    signingCredentials: creds);
                // return token;
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
               // var tokenString = BuildToken(user);
                    response = Ok(new { token = tokenString , claims = claims , expiration = DateTime.Now.AddMinutes(90) , currentUser = login });
                }
                return response;

            }
            catch (Exception ex)
            {
                return Json(new { error = ex.ToString() });
            }
         
        }

        //private string BuildToken(UserModel user)
        //{


        //}
        [AllowAnonymous]
      //  [AuthorizationFilterFactory(InterfaceName = "User", EventAccess = "AllowEdit")]
        [HttpPost("ResetPassword", Name = "ResetPassword")]
        public ActionResult ResetPassword([FromBody]UserModel user)
        {
            try
            {
                if (user.UserName != null && user.Password != null && user.NewPassword != null)
                {
                    var _user = _uow.Repository<User>().Get(x => x.UserName == user.UserName && x.UserPassword == user.Password)[0];
                    if (_user != null)
                    {
                        _user.UserPassword = user.NewPassword;
                        _user.LastModifiedBy = Convert.ToInt32(_user.UserId);
                        _user.LastModifiedDateTime = DateTime.Now;
                        _uow.Repository<User>().Update(_user);
                        _uow.Save();
                        return Json(true);
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return null;
        }
        private UserModel Authenticate(LoginModel login)
            {
                UserModel user = null;
            //_genericRepository.ExecSql("UserAccess_DeleteByRoleID"
            //, new System.Data.SqlClient.SqlParameter("@UserName", SqlDbType.Int) { Value = login.Username }
            //, new System.Data.SqlClient.SqlParameter("@Password", SqlDbType.Int) { Value = login.Username }
            //);
           
            List<User> _user = (List<User>) _genericRepository.ExecSql("select * from PR_WEMSPORTAL.dbo.[User] where username='" + login.Username + "' and userpassword = '" + login.Password + "'");

            //var result = DbAccess.ExecuteQuery(DbAccess.DBPortal, "select userid=1,* from PR_WEMS.dbo.WEMS_SystemUsers where username='" + login.Username + "' and userpassword = '" + login.Password + "'", new Dictionary<string, System.Data.SqlClient.SqlParameter>() {});
            //if (result != null)
            //{
            //    if (result.Tables.Count > 0)
            //    {
            //        for (int i = 0; i < result.Tables.Count; i++)
            //        {
            //            if (result.Tables[i].Rows.Count > 0)
            //            {
            //                return result.Tables[i].ToJson();
            //            }
            //        }
            //    }
            //}
            //var _user = _genericRepository.Get(x => x.UserName == login.Username && x.UserPassword == login.Password).Count;
            if (_user != null)
            {
                if (_user.Count > 0)

                    user = new UserModel
                    {
                        Name = _user[0].PersonName,
                        UserPassword = _user[0].PersonName,
                        UserCode = _user[0].UserId,
                        RoleCode = _user[0].RoleCode,
                        ClaimApprovalLimit = _user[0].ClaimApprovalLimit,
                        Email = _user[0].Email,
                        IUD = _user[0].IUD,
                    };
            }
            return user;
            }

           

           
        }
    }
