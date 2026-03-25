namespace APBD02.Models;

public class Camera : Equipment
{
    public string Sensor { get; set; }
    public bool ImageStabilization { get; set; }

    public Camera(string name, string sensor, bool imageStabilization) : base(name)
    {
        Sensor = sensor;
        ImageStabilization = imageStabilization;
    }
}