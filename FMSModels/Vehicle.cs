﻿using System;
using System.Collections.Generic;

namespace FMS_Backend;

public partial class Vehicle
{
    public int Vehicleid { get; set; }

    public string? Vehicletype { get; set; }

    public string? Fueltype { get; set; }

    public string? Fuelefficiency { get; set; }

    public int? Userid { get; set; }
}