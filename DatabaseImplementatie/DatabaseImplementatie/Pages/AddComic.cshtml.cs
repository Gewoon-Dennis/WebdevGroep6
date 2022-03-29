using DatabaseImplementatie.Models;
using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.BouncyCastle.Crypto.Agreement.JPake;

namespace DatabaseImplementatie.Pages;

public class AddComic : PageModel
{
    [BindProperty] public uitgave NieuweUitgave { get; set; }
    [BindProperty] public reeks ReeksNaam { get; set; }
    [BindProperty] public uitgever UitgeverNaam { get; set; }
    [BindProperty] public tekenaar TekenaarNaam { get; set; }
    [BindProperty] public schrijver SchrijverNaam { get; set; }
    
    public IEnumerable<schrijverPak> schrijverList { get; set; }

    public RedirectToPageResult OnGet()
    {
        schrijverList = new artiestRepository().GetSchrijvers();
        if (Login.LoggedIn == false)
        {
            return new RedirectToPageResult("Login");
        }
       
        return null;
    }
    public void OnPost()
    {
        var a = Request.Form["schrijverr"];
        NieuweUitgave.uitgave_id = Guid.NewGuid();
        ReeksNaam.reeks_id = Guid.NewGuid();
        UitgeverNaam.uitgever_id = Guid.NewGuid();
        TekenaarNaam.tekenaar_id = Guid.NewGuid();
        SchrijverNaam.schrijver_id = Guid.NewGuid();

        NieuweUitgave.reeks_id = ReeksNaam.reeks_id;
        NieuweUitgave.uitgever_id = UitgeverNaam.uitgever_id;
        NieuweUitgave.schrijver_id = SchrijverNaam.schrijver_id;
        NieuweUitgave.tekenaar_id = TekenaarNaam.tekenaar_id;
        NieuweUitgave.verified = false;
        
        new uitgaveRepository().AddUitgave(NieuweUitgave, ReeksNaam, UitgeverNaam, TekenaarNaam, SchrijverNaam);
    }
}