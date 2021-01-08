using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db; 
    public MachinesController(FactoryContext db)
    {
      _db = db; 
    }
    public ActionResult Index()
    {
      List<Machine> model = _db.Machines
        .Include(machine => machine.Machines)
        .ThenInclude(join => join.Machine)
        .ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(); 
    }
    [HttpPost]
    public ActionResult Create(Machine machine, int EngineerId)
    {
      _db.Engineers.Add(engineer);
      if (MachineId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() {EngineerId = machine.MachineId, EngineerId = EngineerId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    } 
  }
}