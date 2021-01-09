using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class HomeController : Controller 
  {
    private readonly FactoryContext _db; 
    public HomeController(FactoryContext db)
    {
      _db = db; 
    }
    [HttpGet("/")]
    public ActionResult Index()
    {
      List<EngineerMachine> model = _db.EngineerMachine
        .Include(engineerMachine => engineerMachine.Machines)
        .Include(engineerMachine => engineerMachine.Engineers)
        .ToList();
      return View(model); 
    }
  }
}