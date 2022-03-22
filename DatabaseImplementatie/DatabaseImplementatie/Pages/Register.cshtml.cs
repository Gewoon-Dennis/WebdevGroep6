using DatabaseImplementatie.Models;
using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseImplementatie.Pages;

public class Register : PageModel
{
    [BindProperty] public Gebruiker Nieuwegebruiker { get; set; }
    [BindProperty] public string WachtwoordCheck { get; set; }
    [BindProperty] public bool PasswordSame { get; set; } = true;
    public void OnGet()
    {
        
    }

    public IActionResult OnPostRegister()
    {
        Nieuwegebruiker.Gebruiker_id = Guid.NewGuid();
        Nieuwegebruiker.Rol = "Verzamelaar";
        

        if (Nieuwegebruiker.Wachtwoord == WachtwoordCheck && WachtwoordCheck.Length >= 6)
        {
            var addCafeUser = new gebruikerRepository().AddNewUser(Nieuwegebruiker);
            return new RedirectToPageResult("Login");
        }
        else
        {
            PasswordSame = false;
            return null;
        }
    }
}