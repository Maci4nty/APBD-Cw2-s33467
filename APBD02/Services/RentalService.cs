using System;
using System.Collections.Generic;
using APBD02.Enums;
using APBD02.Exceptions;
using APBD02.Models;

namespace APBD02.Services;

public class RentalService
{
    List<Equipment> equipments = new List<Equipment>();
    List<User> users = new List<User>();
    List<Rental> rentals = new List<Rental>();

    public void AddUsr(User user)
    {
        users.Add(user);
    }

    public void AddEquipment(Equipment equipment)
    {
        equipments.Add(equipment);
    }

    public Rental RentEquipment(User usr, Equipment eq, int days)
    {
        int count = 0;
        foreach (Rental rent in rentals)
        {
            if (rent.RentedBy == usr)
            {
                if (rent.ActualReturnDate == null)
                {
                    count++;
                }
            }
        }

        if (eq.Status != EquipmentStatus.Available)
        {
            throw new EquipmentUnavailableException("Niedostępne");
        }

        if (usr.Type == UserType.Student && count >= 2)
        {
            throw new UserLimitExceededException("Wykorzystano maksymalną liczbę wypożyczeń jednocześnie");
        }

        if (usr.Type == UserType.Employee && count >= 5)
        {
            throw new UserLimitExceededException("Wykorzystano maksymalną liczbę wypożyczeń jednocześnie");
        }
        
        eq.Status = EquipmentStatus.Rented;
        Rental newRental = new Rental(usr, eq, days);
        rentals.Add(newRental);
        
        return newRental;
    }

    public void ReturnEquipment(Rental rental, Equipment eq)
    {
        rental.ActualReturnDate = DateTime.Now;
        eq.Status = EquipmentStatus.Available;
        
        if (rental.ActualReturnDate > rental.ReturnDate)
        {
            TimeSpan delay = rental.ActualReturnDate.Value - rental.ReturnDate;
            int daysLate = delay.Days;

            if (daysLate > 0)
            {
                rental.AdditionalCharges = daysLate * 10;
            }
        }
    }

    public void ShowALl()
    {
        Console.WriteLine("Cały asortyment");
        foreach (var e in equipments)
        {
            Console.WriteLine($"Nazwa: {e.Name} | Status: {e.Status}");
        }
    }

    public void ShowAvailable()
    {
        Console.WriteLine("Dostępny sprzęt");
        foreach (var eq in equipments)
        {
            if (eq.Status == EquipmentStatus.Available)
            {
                Console.WriteLine($"{eq.Name}");
            }
        }
    }

    public void SetUnavailable(Equipment eq)
    {
        eq.Status = EquipmentStatus.Unavailable;
        Console.WriteLine($"Sprzęt: {eq.Name} został ozanczony jako niedostępny");
    }

    public void ShowUserRentals(User usr)
    {
        Console.WriteLine($"Aktualne wypożyczenia użytkownika: {usr.FirstName} {usr.LastName}");
        foreach (var rent in rentals)
        {
            if (rent.RentedBy == usr && rent.ActualReturnDate == null)
            {
                Console.WriteLine($"{rent.RentedEquipment.Name} do {rent.ReturnDate.ToShortDateString()}");
            }
        }
    }

    public void ShowExpiredRentals()
    {
        Console.WriteLine("Wypożyczenia po terminie oddania");
        foreach (var rental in rentals)
        {
            if (rental.ActualReturnDate == null && rental.ReturnDate < DateTime.Now)
            {
                Console.WriteLine($"{rental.RentedEquipment.Name} wypożyczony przez {rental.RentedBy.LastName}");
            }
        }
    }

    public void ShowFinal()
    {
        int total = 0;
        foreach (var e in equipments)
        {
            if (e.Status == EquipmentStatus.Rented)
            {
                total++;
            }
        }
        
        Console.WriteLine("Finalny raport");
        Console.WriteLine($"Zarjestrowany sprzęt: {equipments.Count}");
        Console.WriteLine($"Zarjestrowany użytkownicy: {users.Count}");
        Console.WriteLine($"Aktualnie wypożyczone: {total}");
    }
}