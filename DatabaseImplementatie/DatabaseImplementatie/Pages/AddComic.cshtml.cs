using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseImplementatie.Pages;

public class AddComic : PageModel
{
    [BindProperty]
    public string titel { get; set; }
    [BindProperty]
    public long isbn { get; set; }
    [BindProperty]
    public int druk { get; set; }
    [BindProperty]
    public string taal { get; set; }
    [BindProperty]
    public int jaar { get; set; }
    [BindProperty]
    public int blz { get; set; }
    [BindProperty]
    public long barcode { get; set; }
    [BindProperty]
    public int expliciet { get; set; }
    [BindProperty]
    public string afmetingen { get; set; }
    [BindProperty]
    public string reeks { get; set; }
    [BindProperty]
    public string uitgever { get; set; }

    public string FormResultaat { get; set; } = "";
    
    public void OnPost()
    {
        new uitgaveRepository().AddData(titel, isbn, druk, taal, jaar, blz, barcode, expliciet, afmetingen, reeks, uitgever);

        
    }
}