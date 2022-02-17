using DatabaseImplementatie.Models;
using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseImplementatie.Pages;

public class Ophalen : PageModel
{
    public void OnGet()
    {
        Resultaat = new afmetingenRepository().GetAll();
    }
    
    public IEnumerable<afmetingen> Resultaat { get; set; }
    
}