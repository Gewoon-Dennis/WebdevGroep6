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
        var schrijverID = Request.Form["schrijverr"];
        NieuweUitgave.uitgave_id = Guid.NewGuid().ToString();
        
        ReeksNaam.reeks_id = Guid.NewGuid().ToString();
        UitgeverNaam.uitgever_id = Guid.NewGuid().ToString();
        TekenaarNaam.tekenaar_id = Guid.NewGuid().ToString();
        if (schrijverID == "0000")
        {
            SchrijverNaam.schrijver_id = Guid.NewGuid().ToString();
            NieuweUitgave.schrijver_id = SchrijverNaam.schrijver_id;
        }
        else
        {
            NieuweUitgave.schrijver_id = schrijverID;
        }
        NieuweUitgave.reeks_id = ReeksNaam.reeks_id;
        NieuweUitgave.uitgever_id = UitgeverNaam.uitgever_id;
        
        NieuweUitgave.tekenaar_id = TekenaarNaam.tekenaar_id;
        NieuweUitgave.verified = false;
        
        new uitgaveRepository().AddUitgave(NieuweUitgave, ReeksNaam, UitgeverNaam, TekenaarNaam, SchrijverNaam);
        schrijverList = new artiestRepository().GetSchrijvers();
    }
}