using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db; 
    public EngineersController(FactoryContext db)
    {
      _db = db; 
    }
    public ActionResult Index()
    {
      List<Engineer> model = _db.Engineers
        .Include(engineer => engineer.Machines)
        .ThenInclude(join => join.Machine)
        .ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(); 
    }
    [HttpPost]
    public ActionResult Create(Engineer engineer, int MachineId)
    {
      _db.Engineers.Add(engineer);
      if (MachineId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() {EngineerId = engineer.EngineerId, MachineId = MachineId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    } 
  }
}