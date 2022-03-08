using DatabaseImplementatie.Models;
using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseImplementatie.Pages;

public class Ophalen : PageModel
{
    public void OnGet()
    {
        ResultaatUitgave = new uitgaveRepository().GetAll();
        
    }
    
    public void OnPostReeks()
    {
        ResultaatUitgave = new uitgaveRepository().GetReeks();
    }
    public void OnPostAZ()
    {
        ResultaatUitgave = new uitgaveRepository().GetAZ();
    }

    public IEnumerable<uitgave> ResultaatUitgave { get; set; }
    
}