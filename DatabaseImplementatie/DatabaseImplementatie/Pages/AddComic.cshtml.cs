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
    
    
    public IEnumerable<schrijver> schrijverList { get; set; }
    public IEnumerable<tekenaar> tekenaarList { get; set; }
    public IEnumerable<uitgever> uitgeverList { get; set; }
    public IEnumerable<reeks> reeksList { get; set; }

    public RedirectToPageResult OnGet()
    {
        schrijverList = new artiestRepository().GetSchrijvers();
        tekenaarList = new artiestRepository().GetTekenaars();
        uitgeverList = new artiestRepository().GetUitgevers();
        reeksList = new artiestRepository().GetReeks();
        
        if (Login.LoggedIn == false)
        {
            return new RedirectToPageResult("Login");
        }
       
        return null;
    }
    public RedirectToPageResult OnPost()
    {
        var schrijverID = Request.Form["schrijverr"];
        var tekenaarID = Request.Form["tekenaarr"];
        var ReeksID = Request.Form["reeksr"];
        var UitgeverID = Request.Form["uitgeverr"];
        
        NieuweUitgave.uitgave_id = Guid.NewGuid().ToString();


        if (UitgeverID == "0000")
        {
            UitgeverNaam.uitgever_id = Guid.NewGuid().ToString();
            NieuweUitgave.uitgever_id = UitgeverNaam.uitgever_id;
        }
        else
        {
            NieuweUitgave.uitgever_id = UitgeverID;
        }
        
        if (ReeksID == "0000")
        {
            ReeksNaam.reeks_id = Guid.NewGuid().ToString();
            NieuweUitgave.reeks_id = ReeksNaam.reeks_id;
        }
        else
        {
            NieuweUitgave.reeks_id = ReeksID;
        }
        if (tekenaarID == "0000")
        {
            TekenaarNaam.tekenaar_id = Guid.NewGuid().ToString();
            NieuweUitgave.tekenaar_id = TekenaarNaam.tekenaar_id;

        }
        else
        {
            NieuweUitgave.tekenaar_id = tekenaarID;
        }
        
        if (schrijverID == "0000")
        {
            SchrijverNaam.schrijver_id = Guid.NewGuid().ToString();
            NieuweUitgave.schrijver_id = SchrijverNaam.schrijver_id;
        }
        else
        {
            NieuweUitgave.schrijver_id = schrijverID;
        }
        NieuweUitgave.verified = false;
        
        new uitgaveRepository().AddUitgave(NieuweUitgave, ReeksNaam, UitgeverNaam, TekenaarNaam, SchrijverNaam);
        return new RedirectToPageResult("AddComic");
    }
}
