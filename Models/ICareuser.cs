using System;
using System.Collections.Generic;

namespace iCARE.Models;

public partial class ICareuser
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICareadmin? ICareadmin { get; set; }

    public virtual ICareworker? ICareworker { get; set; }

    public virtual ICollection<ModificationHistory> ModificationHistories { get; set; } = new List<ModificationHistory>();

    public virtual UserPassword? UserPassword { get; set; }
}
