namespace APBD02.Models;

public class Laptop : Equipment
{
    public int Ram { get; set; }
    public string Proc { get; set; }
    
    public Laptop(string name, int ram, string proc) : base(name)
        {
        Ram = ram;
        Proc = proc;
        }
}