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
    [BindProperty] public string UitgaveId { get; set; }
    [BindProperty] public string search { get; set; }
    public IEnumerable<UitgavePak> UitgaveList { get; set; }
    
    
    public void OnGet()
    {
        string Zoekterm = HttpContext.Session.GetString("ZoekTerm");
        if (Zoekterm != null)
        {
            UitgaveList = new uitgaveRepository().ZoekUitgave(Zoekterm);
            HttpContext.Session.Remove("ZoekTerm");
        }
        else
        {
           UitgaveList = new uitgaveRepository().GetAll(); 
        }
        
        
    }
    
    public void OnPostReeks()
    {
        UitgaveList = new uitgaveRepository().GetReeks();
    }
    
    public void OnPostAZ()
    {
        UitgaveList = new uitgaveRepository().GetAZ();
    }
    
    public void OnPostZA()
    {
        UitgaveList = new uitgaveRepository().GetZA();
    }

    public void OnPostUitgever()
    {
        UitgaveList = new uitgaveRepository().GetUitgever();
    }

    public void OnPostSchrijver()
    {
        UitgaveList = new uitgaveRepository().GetSchrijver();
    }

    public void OnPostTekenaar()
    {
        UitgaveList = new uitgaveRepository().GetTekenaar();
    }
    public RedirectToPageResult OnPostCollectie()
    {
        HttpContext.Session.SetString("uitgaveId", UitgaveId);
        return new RedirectToPageResult("ComicToCollection");
    }

    public void OnPostUnVerify()
    {
        bool Verify = new uitgaveRepository().UnVerifyComic(UitgaveId);
        if (Verify)
        {
            UitgaveList = new uitgaveRepository().GetAll();
        }
    }
    
    public void OnPostZoekComic()
    {
        UitgaveList = new uitgaveRepository().ZoekUitgave(search);
    }
    
}