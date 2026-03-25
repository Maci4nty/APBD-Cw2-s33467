using System;
using APBD02.Enums;

namespace APBD02.Models;

public abstract class Equipment
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public EquipmentStatus Status { get; set; }

    protected Equipment(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        Status = EquipmentStatus.Available;
    }
}