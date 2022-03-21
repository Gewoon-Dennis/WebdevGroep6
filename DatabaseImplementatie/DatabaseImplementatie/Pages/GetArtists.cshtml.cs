using DatabaseImplementatie.Models;
using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseImplementatie.Pages;

public class GetArtists : PageModel
{
    public void OnGet()
    {
        ResultaatArtiest = new artiestRepository().GetAll();
    }
    
    public IEnumerable<artiest> ResultaatArtiest { get; set; }
}