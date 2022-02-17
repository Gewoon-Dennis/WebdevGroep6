using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseImplementatie.Pages;

public class Toevoegen : PageModel
{
    public void OnGet()
    {
        
    }
    
    public void OnPost([FromForm] long isbn, [FromForm] float lengte, [FromForm] float breedte, [FromForm] float dikte, [FromForm] float hoogte)
    {
        new afmetingenRepository().AddData(isbn,lengte, breedte, dikte, hoogte);
    }
}