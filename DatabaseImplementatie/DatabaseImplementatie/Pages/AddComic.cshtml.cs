using DatabaseImplementatie.Models;
using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseImplementatie.Pages;

public class AddComic : PageModel
{
    [BindProperty] public C_uitgave NieuweUitgave { get; set; }
    [BindProperty] public reeks ReeksNaam { get; set; }
    [BindProperty] public uitgever UitgeverNaam { get; set; }
    [BindProperty] public tekenaar TekenaarNaam { get; set; }
    [BindProperty] public schrijver SchrijverNaam { get; set; }
  
    public void OnPost()
    {
        NieuweUitgave.C_uitgave_id = Guid.NewGuid();
        ReeksNaam.C_reeks_id = Guid.NewGuid();
        UitgeverNaam.C_uitgever_id = Guid.NewGuid();
        TekenaarNaam.C_tekenaar_id = Guid.NewGuid();
        SchrijverNaam.C_schrijver_id = Guid.NewGuid();

        NieuweUitgave.C_reeks_id = ReeksNaam.C_reeks_id;
        NieuweUitgave.C_uitgever_id = UitgeverNaam.C_uitgever_id;
        NieuweUitgave.C_schrijver_id = SchrijverNaam.C_schrijver_id;
        NieuweUitgave.C_tekenaar_id = TekenaarNaam.C_tekenaar_id;
        NieuweUitgave.C_verified = false;
        
        new uitgaveRepository().AddUitgave(NieuweUitgave, ReeksNaam, UitgeverNaam, TekenaarNaam, SchrijverNaam);
    }
}