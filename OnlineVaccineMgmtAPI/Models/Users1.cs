﻿using System;
using System.Collections.Generic;

namespace OnlineVaccineMgmtAPI.Models;

public partial class Users1
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int UserType { get; set; }
}
