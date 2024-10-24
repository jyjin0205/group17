using System;
using System.Collections.Generic;

namespace Group17_iCAREAPP.Models;

public partial class GeoCode
{
    public string Id { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual PatientRecord? PatientRecord { get; set; }
}
