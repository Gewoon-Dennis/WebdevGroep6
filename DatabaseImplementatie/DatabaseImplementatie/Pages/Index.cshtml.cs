using Dapper;
using DatabaseImplementatie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace DatabaseImplementatie.Pages;

public class IndexModel : PageModel
{
    [BindProperty] public string search { get; set; }
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public RedirectToPageResult OnPostZoekComic()
    {
        HttpContext.Session.SetString("ZoekTerm", search);
        return new RedirectToPageResult("GetUitgave");
    }

}