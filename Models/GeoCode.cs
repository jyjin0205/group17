using System;
using System.Collections.Generic;

namespace iCARE.Models;

public partial class GeoCode
{
    public string Id { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<PatientRecord> PatientRecords { get; set; } = new List<PatientRecord>();
}
