using Dapper;
using DatabaseImplementatie.Models;
using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace DatabaseImplementatie.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnPost([FromForm] long isbn, [FromForm] float lengte, [FromForm] float breedte, [FromForm] float dikte, [FromForm] float hoogte)
    {
        new afmetingenRepository().AddData(isbn,lengte, breedte, dikte, hoogte);
    }

}