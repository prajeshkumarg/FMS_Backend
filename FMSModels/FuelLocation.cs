using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace FMS_Backend;

public partial class FuelLocation
{
    public int Locid { get; set; }

    public string? Locname { get; set; }

    public string? Address { get; set; }

    public NpgsqlPoint? Geocode { get; set; }
}
