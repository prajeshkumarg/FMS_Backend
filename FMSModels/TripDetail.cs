using System;
using System.Collections.Generic;

namespace FMS_Backend.FMSModels;

public partial class TripDetail
{
    public int? Vehicleid { get; set; }

    public int? Userid { get; set; }

    public DateOnly? Tripdatetime { get; set; }

    public double? Odometerstart { get; set; }

    public double? Odometerend { get; set; }

    public double? Fuelstart { get; set; }

    public double? Fuelend { get; set; }

    public double? Tripmileage { get; set; }

    public int? Tripid { get; set; }
}
