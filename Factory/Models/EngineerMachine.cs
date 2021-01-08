namespace Factory.Models
{
  public class EngineerMachine
  {
    public int EngineerMachineId { get; set; }
    public int EngineerId { get; set; }
    public int MachineId { get; set; }
    public Engineer Engineer { get; set; } //Are we storing the objects? what's the point of having this in our model? 
    public Machine Machine { get; set; } //specifying databases that are connected for built in entity functions to work. 
  }
}