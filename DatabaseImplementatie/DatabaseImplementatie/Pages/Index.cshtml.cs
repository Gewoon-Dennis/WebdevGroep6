using Dapper;
using DatabaseImplementatie.Models;
using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace DatabaseImplementatie.Pages;

public class IndexModel : PageModel
{
    [BindProperty] public string search { get; set; }
    private readonly ILogger<IndexModel> _logger;
    public IEnumerable<UitgavePak> UitgaveList { get; set; }

    public void OnGet()
    {
        UitgaveList = new uitgaveRepository().GetFrontPage();
    }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public RedirectToPageResult OnPostZoekComic()
    {
        if (search != null)
        {
            HttpContext.Session.SetString("ZoekTerm", search);
            return new RedirectToPageResult("GetUitgave"); 
        }

        return null;
    }

}