using DatabaseImplementatie.Models;
using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseImplementatie.Pages;

public class GetArtists : PageModel
{
    public void OnGet()
    {
        SchrijverList = new artiestRepository().GetSchrijvers();
        TekenaarList = new artiestRepository().GetTekenaars();
    }
    
    public IEnumerable<schrijver> SchrijverList { get; set; }
    public IEnumerable<tekenaar> TekenaarList { get; set; }
}