using DatabaseImplementatie.Models;
using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseImplementatie.Pages;

public class AdminScreen : PageModel
{
    [BindProperty] public string GebruikerMail {get; set; }
    [BindProperty] public string GerbuikerId { get; set; }
    [BindProperty] public string UitgaveId { get; set; }
    public IEnumerable<Gebruiker> GebruikerList { get; set; }
    public IEnumerable<UitgavePak> UitgaveList { get; set; }
    
    public RedirectToPageResult OnGet()
    {
        if (Login.LoggedIn)
        {
            if (Login.IsModerator == false)
            {
                return new RedirectToPageResult("Account");
            }
        }
        else 
        {
            return new RedirectToPageResult("Login");
        }
        UitgaveList = new uitgaveRepository().GetUnverified();
        return null;
    }

    public void OnPostZoekGebruiker()
    {
        GebruikerList = new gebruikerRepository().GetUserRole(GebruikerMail);
        UitgaveList = new uitgaveRepository().GetUnverified();
    }

    public void OnPostPromote()
    {
        bool Promote = new gebruikerRepository().PromoteUser(GerbuikerId);
        GebruikerList = new gebruikerRepository().GetUserRole(GebruikerMail);
        UitgaveList = new uitgaveRepository().GetUnverified();
    }

    public void OnPostDemote()
    {
        bool Demote = new gebruikerRepository().DemoteUser(GerbuikerId);
        GebruikerList = new gebruikerRepository().GetUserRole(GebruikerMail);
        UitgaveList = new uitgaveRepository().GetUnverified();
    }

    public void OnPostVerify()
    {
        bool Verify = new uitgaveRepository().VerifyComic(UitgaveId);
        if (Verify)
        {
            UitgaveList = new uitgaveRepository().GetUnverified();
        }
    }
    public void OnPostDelete()
    { 
        bool Delete = new uitgaveRepository().DeleteComic(UitgaveId);
        if (Delete)
        {
            UitgaveList = new uitgaveRepository().GetUnverified();
        }
    }
    
}