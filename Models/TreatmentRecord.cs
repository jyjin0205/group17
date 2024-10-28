using System;
using System.Collections.Generic;

namespace iCARE.Models;

public partial class TreatmentRecord
{
    public string TreatmentId { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateOnly TreatmentDate { get; set; }

    public string PatientId { get; set; } = null!;

    public string WorkerId { get; set; } = null!;

    public virtual PatientRecord Patient { get; set; } = null!;

    public virtual ICareworker Worker { get; set; } = null!;
}
