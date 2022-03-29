using DatabaseImplementatie.Models;
using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseImplementatie.Pages;

public class Account : PageModel
{
    [BindProperty] public string Uitgave_Id { get; set; }
    public IEnumerable<collectie> CollectieList { get; set; }
    public RedirectToPageResult OnGet()
    {
        if (Login.LoggedIn == false)
        {
            return new RedirectToPageResult("Login");
        }
        
        HttpContext.Session.Remove("uitgaveId");
        string gebruiker_id = HttpContext.Session.GetString("LogIn");
        CollectieList = new uitgaveRepository().GetCollectie(gebruiker_id);
       
        return null;
        
    }
    
    public RedirectToPageResult OnPostUitCollectie()
    {
        string Gebruiker_Id = HttpContext.Session.GetString("LogIn");
        bool RemovedComic = new uitgaveRepository().RemoveFromCollection(Uitgave_Id, Gebruiker_Id);
        if (RemovedComic)
        {
            return new RedirectToPageResult("Account");
        }

        return null;
    }
}