using System;
using System.Collections.Generic;

namespace OnlineVaccineMgmtAPI.Models;

public partial class Appointment1
{
    public int AppointmentId { get; set; }

    public int UserId { get; set; }

    public int VaccineId { get; set; }

    public DateTime AppointmentDateTime { get; set; }

    public string Status { get; set; } = null!;
}
