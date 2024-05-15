using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userModel = new ApplicationUser();
                userModel.Email = userDTO.Email;
                userModel.UserName = userDTO.UserName;
               IdentityResult result=await userManager.CreateAsync(userModel,userDTO.Password);

                if (result.Succeeded)
                {
                    return Ok("Created Success");
                }
                else
                {
                    return BadRequest(result.Errors.First());
                }

            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userModel=await userManager.FindByNameAsync(userDTO.UserName);
                if (userModel != null && await userManager.CheckPasswordAsync(userModel,userDTO.Password))
                {
                    List<Claim> myClaims=new List<Claim>();
                    //id,name,jit
                    myClaims.Add(new Claim(ClaimTypes.NameIdentifier, userModel.Id));
                    myClaims.Add(new Claim(ClaimTypes.Name, userModel.UserName));
                    myClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                    var roles = await userManager.GetRolesAsync(userModel);
                    if (roles.Any())
                    {
                        foreach (var item in roles)
                        {
                            myClaims.Add(new Claim(ClaimTypes.Role, item));
                        }
                    }
                    var authSecuritKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asd123zxcdgdsfgdfsasdsadsadsadasddksadasd"));
                    SigningCredentials credentials =
                        new SigningCredentials(authSecuritKey, SecurityAlgorithms.HmacSha256);

                    JwtSecurityToken mytoken =new JwtSecurityToken(
                        issuer:"http://localhost:59179",
                        audience:"http://localhost:4200",
                        expires: DateTime.Now.AddHours(1),
                        claims:myClaims,
                        signingCredentials: credentials
                        );

                    return Ok(new{
                        token=new JwtSecurityTokenHandler().WriteToken(mytoken),
                        expires=mytoken.ValidTo
                    });
                }
            }
            return BadRequest(ModelState);
        }
    }
}
