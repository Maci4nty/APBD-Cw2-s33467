namespace APBD02.Models;

public class Projector : Equipment
{
    public int Lumen { get; set; }
    public string Resolution { get; set; }

    public Projector(string name, int lumen, string resolution) : base(name)
    {
        Lumen = lumen;
        Resolution = resolution;
    }
}