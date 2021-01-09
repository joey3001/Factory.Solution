using System.Collections.Generic;

namespace Factory.Models
{
  public class EngineerMachine
  {
    public int EngineerMachineId { get; set; }
    public int EngineerId { get; set; }
    public int MachineId { get; set; }
    public Engineer Engineer { get; set; } 
    public Machine Machine { get; set; } 

    public EngineerMachine()
    {
      this.Machines = new HashSet<Machine>(); 
      this.Engineers = new HashSet<Engineer>(); 
    }
    public ICollection<Machine> Machines { get; set; } 
    public ICollection<Engineer> Engineers { get; set; } 
  }
}