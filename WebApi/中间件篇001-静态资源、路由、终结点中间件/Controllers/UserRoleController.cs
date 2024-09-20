using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using NET_FiveMinutes_008_UseIdentity.Common;
using NET_FiveMinutes_008_UseIdentity.Models;

namespace NET_FiveMinutes_008_UseIdentity.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserRoleController : ODataController
    {
        private readonly ILogger<UserRoleController> logger;
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<User> userManager;

        public UserRoleController(ILogger<UserRoleController> logger, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            this.logger = logger;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUserRole(string roleName,string userName,string userEmail,string userPassword)
        {
            bool roleExists = await roleManager.RoleExistsAsync(roleName);

            if (!roleExists)
            {
                Role role = new Role() {Name = roleName};
                var r = await roleManager.CreateAsync(role);

                if(r != null)
                {
                    return BadRequest(r.Errors);
                }
            }

            User user = await this.userManager.FindByNameAsync(userName);
            if(user == null)
            {
                user = new User()
                {
                    UserName = userName,
                    Email = userEmail,
                    EmailConfirmed = true
                };

                var r = await userManager.CreateAsync(user,userPassword);
                if(!r.Succeeded)
                {
                    return BadRequest(r.Errors);
                }

                r = await userManager.AddToRoleAsync(user,roleName);
                if(!r.Succeeded)
                {
                    return BadRequest(r.Errors);
                }
            }

            return Ok();
        }

        [HttpGet]
        [EnableQuery]
        public ActionResult GetRoleManager()
        {
            var roles = this.roleManager.Roles.ToList();
            return Ok(roles);
        }

        [HttpGet]
        [EnableQuery]
        public ActionResult GetUserManager()
        {
            var users = this.userManager.Users.ToList();
            return Ok(users);
        }

        // 根据指定id查询
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult> GetUserByEmail([FromODataUri] string id)
        {
            var usr = await this.userManager.FindByIdAsync(id);
            return Ok(usr);
        }

        //删除
        [HttpDelete]
        [EnableQuery]
        public async Task<ActionResult> DeleteUser([FromODataUri] int key)
        {
            var deleteUser = this.userManager.Users.FirstOrDefault(p => p.Id == key);
            if (deleteUser == null) return NotFound();

            var r = await this.userManager.DeleteAsync(deleteUser);
            return Ok(r); 
        }
        
        [HttpGet]
        public async Task<ActionResult> Login(string userName,string password)
        {
            var user = await this.userManager.FindByNameAsync(userName);

            if(user == null)
            {
                return NotFound($"用户名不存在{user.UserName}");
            }

            // 判断用户是否被锁定
            if(await userManager.IsLockedOutAsync(user))
            {
                return BadRequest("LockedOut");
            }

            if(await userManager.CheckPasswordAsync(user,password))
            {
                return Ok("登录成功");
            }
            else
            {
                // 记录一次用户登录失败，如果次数过多，则会对账户进行锁定
                // 账户默认锁定时间是5min，登录失败次数默认为5次
                await userManager.AccessFailedAsync(user);
                return NotFound($"密码不正确");
            }
        }

        /// <summary>
        /// 发送重置密码请求
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> SendRestPasswordToken(string email,string newPassword)
        {
            var user = await userManager.FindByEmailAsync(email);
            string token = await userManager.GeneratePasswordResetTokenAsync(user);
            logger.LogInformation($"向邮箱{user.Email}发送{token}");
            return Ok($"向邮箱{user.Email}发送Token{token}");
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> VerifyResetPasswordToken(string email,string token,string password)
        {
            var user = await userManager.FindByEmailAsync(email);
            var r = await userManager.ResetPasswordAsync(user,token,password);
            if(r.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(r.Errors);
            }
        }
    }
}
