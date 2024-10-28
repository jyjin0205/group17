using System;
using System.Collections.Generic;

namespace iCARE.Models;

public partial class PatientRecord
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public double? Height { get; set; }

    public double? Weight { get; set; }

    public string? BloodGroup { get; set; }

    public string? BedId { get; set; }

    public string? TreatmentArea { get; set; }

    public string? GeographicalUnit { get; set; }

    public string? ModifierId { get; set; }

    public virtual ICollection<DocumentMetadatum> DocumentMetadata { get; set; } = new List<DocumentMetadatum>();

    public virtual GeoCode? GeographicalUnitNavigation { get; set; }

    public virtual ICareworker? Modifier { get; set; }

    public virtual ICollection<TreatmentRecord> TreatmentRecords { get; set; } = new List<TreatmentRecord>();
}
