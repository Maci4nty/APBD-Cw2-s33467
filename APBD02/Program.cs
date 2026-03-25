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

Rental rentCam = null;
Rental rentLap = null;

try
{
    Console.WriteLine("Próba wypożyczenia kamery");
    rentCam = rentalServ.RentEquipment(stud, cam, 7);
    Console.WriteLine("Udane wypożyczenie");

    Console.WriteLine("Próba wypożyczenia MacBooka");
    rentLap = rentalServ.RentEquipment(stud, laptop, 4);
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

Console.WriteLine("---Test zwrotu i kar---");

if (rentCam != null)
{
    rentCam.ReturnDate = DateTime.Now.AddMonths(-10);
    Console.WriteLine($"Planowany zwrot: {rentCam.ReturnDate.ToShortDateString()}");
    
    rentalServ.ReturnEquipment(rentCam, cam);
    
    Console.WriteLine($"Faktyczny zwrot:  {rentCam.ActualReturnDate?.ToShortDateString()}");
    Console.WriteLine($"Została naliczona kara w wysokości: {rentCam.AdditionalCharges} zł");
    Console.WriteLine($"Status kamery po zwrocie: {cam.Status}");
}

Console.WriteLine("Oznaczenie sprzętu jako niedostępnego");
rentalServ.SetUnavailable(projector);

Console.WriteLine("Zwrot w terminie");
rentalServ.ReturnEquipment(rentLap, laptop);
Console.WriteLine($"Laptop zwrócony w terminie. Kara: {rentLap.AdditionalCharges} zł");

rentalServ.ShowALl();
Console.WriteLine();

rentalServ.ShowUserRentals(stud);
Console.WriteLine();

rentalServ.ShowAvailable();
Console.WriteLine();

rentalServ.ShowExpiredRentals();
Console.WriteLine();

rentalServ.ShowFinal();


