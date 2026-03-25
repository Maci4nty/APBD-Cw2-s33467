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