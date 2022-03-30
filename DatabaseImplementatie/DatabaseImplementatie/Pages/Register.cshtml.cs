using DatabaseImplementatie.Models;
using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseImplementatie.Pages;

public class Register : PageModel
{
    [BindProperty] public Gebruiker Nieuwegebruiker { get; set; }
    public RedirectToPageResult OnGet()
    {
        
        if (Login.LoggedIn)
        {
            return new RedirectToPageResult("Account");
        }

        return null;
    }

    public IActionResult OnPostRegister()
    {
        Nieuwegebruiker.gebruiker_id = Guid.NewGuid().ToString();
        Nieuwegebruiker.gebruikermail = Nieuwegebruiker.gebruikermail.ToLower();
        Nieuwegebruiker.rol = "Verzamelaar";
        var addCafeUser = new gebruikerRepository().AddNewUser(Nieuwegebruiker);
        return new RedirectToPageResult("Login");
       
    }
}