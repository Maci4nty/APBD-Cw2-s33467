using System;
using APBD02.Enums;
using APBD02.Exceptions;
using APBD02.Models;
using APBD02.Services;

RentalService rentalServ = new RentalService();

User stud = new User("Jan", "Kiełbasa", UserType.Student);
User pracownik = new User("Adam", "Smakosz", UserType.Student);

rentalServ.AddUsr(stud);
rentalServ.AddUsr(pracownik);