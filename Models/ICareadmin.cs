using System;
using System.Collections.Generic;

namespace Group17_iCAREAPP.Models;

public partial class ICareadmin
{
    public string Id { get; set; } = null!;

    public string AdminEmail { get; set; } = null!;

    public DateOnly DateHired { get; set; }

    public DateOnly? DateFinished { get; set; }

    public virtual ICollection<ICareworker> ICareworkers { get; set; } = new List<ICareworker>();

    public virtual ICareuser IdNavigation { get; set; } = null!;
}
