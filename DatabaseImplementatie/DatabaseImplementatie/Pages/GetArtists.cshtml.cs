using DatabaseImplementatie.Models;
using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseImplementatie.Pages;

public class GetArtists : PageModel
{
    [BindProperty] private tekenaar Tekenaar { get; set; }
    [BindProperty] private schrijver Schrijver { get; set; }
    public void OnGet()
    {
        SchrijverList = new artiestRepository().GetSchrijvers();
        TekenaarList = new artiestRepository().GetTekenaars();
    }
    
    public IEnumerable<schrijverPak> SchrijverList { get; set; }
    public IEnumerable<tekenaarPak> TekenaarList { get; set; }
}