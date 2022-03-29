using DatabaseImplementatie.Models;
using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseImplementatie.Pages;

public class Account : PageModel
{
    public IEnumerable<UitgavePak> CollectieList { get; set; }
    public void OnGet()
    {
        HttpContext.Session.Remove("uitgaveId");
        string gebruiker_id = HttpContext.Session.GetString("LogIn");
        CollectieList = new uitgaveRepository().GetCollectie(gebruiker_id);
    }
}