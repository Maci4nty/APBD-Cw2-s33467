using System;

namespace APBD02.Exceptions;

public class EquipmentUnavailableException : Exception
{
    public EquipmentUnavailableException(string? msg) : base(msg) { }
}