using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Crypto.Tls;

namespace DatabaseImplementatie.Pages;

public class Toevoegen : PageModel
{
    public void OnGet()
    {
        
    }
    
    public void OnPost([FromForm] string geboortedatum, [FromForm] string aut_naam, [FromForm] string wikipedia_aut, [FromForm] Int32 is_tekenaar, [FromForm] Int32 is_schrijver)
    {
        new afmetingenRepository().AddData(geboortedatum,aut_naam, wikipedia_aut, is_tekenaar, is_schrijver);
    }
}