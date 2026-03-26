using Microsoft.AspNetCore.Mvc;
using collegemainatanceportal.Data;
using System.Linq;
using Microsoft.Identity.Client;

public class DashboardController : Controller
{
    private readonly ApplicationDbContext _context;

    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.Total = _context.Complaints.Count();
        ViewBag.Pending = _context.Complaints.Count(c => c.Status == "Pending");
        ViewBag.InProgress = _context.Complaints.Count(c => c.Status == "In Progress");
        ViewBag.Completed = _context.Complaints.Count(c => c.Status == "Completed");

        return View();
       
        }
    }


