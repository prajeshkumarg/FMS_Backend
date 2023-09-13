using System;
using System.Collections.Generic;

namespace FMS_Backend;

public partial class FuelInventory
{
    public int Fuelid { get; set; }

    public string? Locid { get; set; }

    public string? Fueltype { get; set; }

    public double? Fuelqty { get; set; }

    public double? Fuelprice { get; set; }

    public int? Fueldensity { get; set; }
}
