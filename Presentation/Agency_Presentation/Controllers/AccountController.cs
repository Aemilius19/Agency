using Agency_Domain;
using Agency_Domain.Helper;
using Agency_Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Agency_Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager,RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        public async Task<IActionResult> CreateRole() 
        {
            foreach (var item in Enum.GetValues(typeof(Role)))
            {
                await roleManager.CreateAsync(new IdentityRole()
                {
                    Name=item.ToString(),
                });

            }
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            User user = new User() 
            { 
               
               Name=registerVM.FirstName,
               Surname=registerVM.LastName,
               Email=registerVM.Email,
               UserName = registerVM.FirstName + registerVM.LastName,
            };

            var result = await userManager.CreateAsync(user, registerVM.Password);
            if (!result.Succeeded) 
            { 
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                    return View();
                }
            }
            await userManager.AddToRoleAsync(user,Role.Member.ToString());
            return RedirectToAction("Login");

        }
        public async Task<IActionResult> LogOut()
        {
           await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM,string? ReturnUrl=null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            User user=new User();
            
            user= await userManager.FindByEmailAsync(loginVM.Email);
            if (user == null) 
            {
                ModelState.AddModelError("", "Email ya password sehfdir");
                return View();
            }
            var result= await signInManager.CheckPasswordSignInAsync(user, loginVM.Password,true);
            if (result.IsLockedOut) 
            {
                ModelState.AddModelError("", "Birazdasn yeniden cehd edin");
                return View();
            }
            if (!result.Succeeded) 
            {
                ModelState.AddModelError("", "Email ya password sehfdir");
                return View();
            }
            
           await signInManager.SignInAsync(user,false);  
            
            if(ReturnUrl!=null) { return Redirect(ReturnUrl); }
            return RedirectToAction("Index", "Home");   
        }

    }
}
