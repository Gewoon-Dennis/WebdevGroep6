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
    public static bool IsModerator = false;
    

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
            IsModerator = false;
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
            string Moderator = new gebruikerRepository().ModeratorCheck(UserId);

            if (Admin == "Admin")
            {
                IsAdmin = true;
                IsModerator = true;
            }

            if (Moderator == "Moderator")
            {
                IsModerator = true;
            }

            return new RedirectToPageResult("Account",false);
        }

        return null;
    }
}