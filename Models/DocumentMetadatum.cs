using System;
using System.Collections.Generic;

namespace Group17_iCAREAPP.Models;

public partial class DocumentMetadatum
{
    public string DocId { get; set; } = null!;

    public string DocName { get; set; } = null!;

    public DateOnly DateOfCreation { get; set; }

    public int? Version { get; set; }

    public string? UserId { get; set; }

    public string? PatientId { get; set; }

    public virtual ICollection<ModificationHistory> ModificationHistories { get; set; } = new List<ModificationHistory>();

    public virtual PatientRecord? Patient { get; set; }

    public virtual ICareworker? User { get; set; }
}
