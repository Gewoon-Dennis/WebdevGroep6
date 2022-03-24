using Dapper;
using DatabaseImplementatie.Models;
using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace DatabaseImplementatie.Pages;

public class GetUitgave : PageModel
{
    [BindProperty] public string comicPage { get; set; }
    
    public void OnGet()
    {
        UitgaveList = new uitgaveRepository().GetAll();
        
    }
    
    public void OnPostReeks()
    {
      //  ResultaatUitgave = new uitgaveRepository().GetReeks();
    }
    public void OnPostAZ()
    {
      //  ResultaatUitgave = new uitgaveRepository().GetAZ();
    }

    public IEnumerable<UitgavePak> UitgaveList { get; set; }

    public void OnPostGetComic()
    {
        
    }
}