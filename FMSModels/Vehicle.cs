using System;
using System.Collections.Generic;

namespace FMS_Backend.FMSModels;

public partial class Vehicle
{
    public string? Vehicletype { get; set; }

    public string? Fueltype { get; set; }

    public string? Fuelefficiency { get; set; }

    public int? Userid { get; set; }

    public int? Vehicleid { get; set; }
}
