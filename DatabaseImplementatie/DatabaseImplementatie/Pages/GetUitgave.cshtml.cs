using System.Net;
using Dapper;
using DatabaseImplementatie.Models;
using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace DatabaseImplementatie.Pages;

public class GetUitgave : PageModel
{
    [BindProperty] public string comicPage { get; set; }
    [BindProperty] public string Id { get; set; }
    public IEnumerable<UitgavePak> UitgaveList { get; set; }
    
    
    public void OnGet()
    {
        UitgaveList = new uitgaveRepository().GetAll();
        
    }
    
    public void OnPostReeks()
    {
        UitgaveList = new uitgaveRepository().GetReeks();
    }
    public void OnPostAZ()
    {
        UitgaveList = new uitgaveRepository().GetAZ();
    }

    

    public RedirectToPageResult OnPostCollectie()
    {
        HttpContext.Session.SetString("uitgaveId", Id);
        return new RedirectToPageResult("ComicToCollection");
    }
    
    
}