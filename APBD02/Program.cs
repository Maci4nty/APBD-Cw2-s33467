using System;
using APBD02.Enums;
using APBD02.Exceptions;
using APBD02.Models;
using APBD02.Services;

RentalService rentalServ = new RentalService();

User stud = new User("Jan", "Kiełbasa", UserType.Student);
User pracownik = new User("Adam", "Smakosz", UserType.Employee);

rentalServ.AddUsr(stud);
rentalServ.AddUsr(pracownik);

Laptop laptop = new Laptop("MacBook Pro", 16, "M5");
Camera cam = new Camera("Sony Alpha 7", "CMOS", true);
Projector projector = new Projector("XGIMI TITAN2", 10000, "1920 x 1200");

rentalServ.AddEquipment(projector);
rentalServ.AddEquipment(cam);
rentalServ.AddEquipment(laptop);

Console.WriteLine("---Wypożyczalnia---");

try
{
    Console.WriteLine("Próba wypożyczenia kamery");
    rentalServ.RentEquipment(stud, cam, 7);
    Console.WriteLine("Udane wypożyczenie");

    Console.WriteLine("Próba wypożyczenia MacBooka");
    rentalServ.RentEquipment(stud, laptop, 4);
    Console.WriteLine("Udane wypożyczenie");

    Console.WriteLine("Próba wypożyczenia projektora");
    rentalServ.RentEquipment(stud, projector, 1);
    Console.WriteLine("Nieudane wypożyczenie");
}
catch (UserLimitExceededException e)
{
    Console.WriteLine(e.Message);
}
catch (EquipmentUnavailableException e)
{
    Console.WriteLine(e.Message);
}
