using System;

namespace APBD02.Models;

public class Rental
{
    public Guid Id { get; set; }
    public User RentedBy { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public Equipment RentedEquipment { get; set; }
    
    public DateTime? ActualReturnDate {get; set;}
    public decimal AdditionalCharges { get; set; }

    public Rental(User rentedBy, Equipment rentedEquipment, int daysToRent)
    {
        Id = Guid.NewGuid();
        RentedBy = rentedBy;
        RentDate = DateTime.Now;
        ReturnDate = RentDate.AddDays(daysToRent);
        RentedEquipment = rentedEquipment;
        AdditionalCharges = 0m;
    }
}