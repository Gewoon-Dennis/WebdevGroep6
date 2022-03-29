using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseImplementatie.Pages;

public class Login : PageModel
{
    [BindProperty] public string Email { get; set; }
    [BindProperty] public string Password { get; set; }
    public static bool LoggedIn = false;
    public static bool IsAdmin = false;
    

    public RedirectToPageResult OnGet()
    {
        string LoginCheck = HttpContext.Session.GetString("LogIn");
        if (LoginCheck != null)
        {
            LoggedIn = true;
            return new RedirectToPageResult("Account");
        }
        else
        {
            LoggedIn = false;
            IsAdmin = false;
        }

        return null;
    }
    public RedirectToPageResult OnPostLogin()
    {
        string login  = new gebruikerRepository().GetVerzamelaar(Email, Password);
        if (login != null)
        {
            LoggedIn = true;
            HttpContext.Session.SetString("LogIn", login);
            string UserId = HttpContext.Session.GetString("LogIn");
            string Admin = new gebruikerRepository().AdminCheck(UserId);

            if (Admin == "Admin")
            {
                IsAdmin = true;
            }
            
            return new RedirectToPageResult("Account",false);
        }

        return null;
    }
}