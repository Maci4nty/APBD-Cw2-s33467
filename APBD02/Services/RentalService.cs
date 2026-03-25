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

    public void RentEquipment(User usr, Equipment eq, int days)
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
}