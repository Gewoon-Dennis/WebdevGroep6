using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseImplementatie.Pages;

public class Login : PageModel
{
    [BindProperty] public string UserName { get; set; }
    [BindProperty] public string Password { get; set; }
    public static bool LoggedIn = false;
    

    public RedirectToPageResult OnGet()
    {
        string LoginCheck = HttpContext.Session.GetString("LogIn");
        if (LoginCheck != null)
        {
            LoggedIn = true;
            return new RedirectToPageResult("Account");
        }

        return null;
    }
    public RedirectToPageResult OnPostLogin()
    {
        string login  = new gebruikerRepository().GetVerzamelaar(UserName, Password);
        if (login != null)
        {
            LoggedIn = true;
            HttpContext.Session.SetString("LogIn", login);
            return new RedirectToPageResult("Account");
        }

        return null;
    }
}