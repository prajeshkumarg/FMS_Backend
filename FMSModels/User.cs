﻿using System;
using System.Collections.Generic;

namespace FMS_Backend.FMSModels;

public partial class User
{
    public int Userid { get; set; }

    public string? Username { get; set; }

    public string? Contact { get; set; }

    public string? Role { get; set; }

    public byte[]? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }
}
