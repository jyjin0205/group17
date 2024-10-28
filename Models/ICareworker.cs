using System;
using System.Collections.Generic;

namespace iCARE.Models;

public partial class ICareworker
{
    public string Id { get; set; } = null!;

    public string Profession { get; set; } = null!;

    public string Creator { get; set; } = null!;

    public string UserPermission { get; set; } = null!;

    public virtual ICareadmin CreatorNavigation { get; set; } = null!;

    public virtual ICollection<DocumentMetadatum> DocumentMetadata { get; set; } = new List<DocumentMetadatum>();

    public virtual ICareuser IdNavigation { get; set; } = null!;

    public virtual ICollection<PatientRecord> PatientRecords { get; set; } = new List<PatientRecord>();

    public virtual ICollection<TreatmentRecord> TreatmentRecords { get; set; } = new List<TreatmentRecord>();

    public virtual UserRole UserPermissionNavigation { get; set; } = null!;
}
