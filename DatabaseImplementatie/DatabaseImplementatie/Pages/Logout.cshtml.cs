using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseImplementatie.Pages;

public class Logout : PageModel
{
    public RedirectToPageResult OnGet()
    {
        HttpContext.Session.Remove("LogIn");
        Login.LoggedIn = false;
        return new RedirectToPageResult("Login");
    }
}