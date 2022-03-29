using DatabaseImplementatie.Models;
using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseImplementatie.Pages;

public class ComicToCollection : PageModel
{
    [BindProperty] public bezit Bezit { get; set; }
    private string gebruiker_id;
    private string uitgave_id;
    public void OnGet()
    {
        
    }

    public RedirectToPageResult OnPostVoegToe()
    {
        gebruiker_id = HttpContext.Session.GetString("LogIn");
        uitgave_id = HttpContext.Session.GetString("uitgaveId");
        Bezit.gebruiker_id = gebruiker_id;
        Bezit.uitgave_id = uitgave_id;
        bool addToCollectie = new uitgaveRepository().AddToCollection(Bezit);
        if (addToCollectie)
        {
           HttpContext.Session.Remove("uitgaveId");
           return new RedirectToPageResult("Account", false); 
        }

        return null;
    }
}