using System;
using System.Collections.Generic;

namespace OnlineVaccineMgmtAPI.Models;

public partial class Vaccines1
{
    public int VaccineId { get; set; }

    public string VaccineName { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public string? Description { get; set; }

    public int AvailableDoses { get; set; }

    public decimal Price { get; set; }
}
