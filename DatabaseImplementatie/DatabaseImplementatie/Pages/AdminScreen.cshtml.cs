using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseImplementatie.Pages;

public class AdminScreen : PageModel
{
    public RedirectToPageResult OnGet()
    {
        if (Login.LoggedIn == true)
        {
            if (Login.IsAdmin == false)
            {
                return new RedirectToPageResult("Account");
            }
        }
        else 
        {
            return new RedirectToPageResult("Login");
        }

        return null;
    }
}