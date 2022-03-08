using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Crypto.Tls;

namespace DatabaseImplementatie.Pages;

public class Toevoegen : PageModel
{
    public void OnGet()
    {
       // int tekenaar = [FromForm] is_tekenaar.checked;
    }
    
    public void OnPost([FromForm] string geboortedatum, [FromForm] string aut_naam, [FromForm] string wikipedia_aut, [FromForm] int is_tekenaar, [FromForm] int is_schrijver)
    {
        new artiestenRepository().AddData(geboortedatum,aut_naam, wikipedia_aut, is_tekenaar, is_schrijver);
    }
}