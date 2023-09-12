using System;
using System.Collections.Generic;

namespace FMS_Backend.FMSModels;

public partial class Transaction
{
    public int Transactionid { get; set; }

    public int? Vehicleid { get; set; }

    public DateOnly? Fuelingdate { get; set; }

    public int? Fuelinglocid { get; set; }

    public int? Userid { get; set; }

    public double? Fuelcost { get; set; }

    public string? Paymentmethod { get; set; }
}
