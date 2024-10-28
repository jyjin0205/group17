using System;
using System.Collections.Generic;

namespace iCARE.Models;

public partial class UserRole
{
    public string Id { get; set; } = null!;

    public string RoleName { get; set; } = null!;

    public virtual ICollection<ICareworker> ICareworkers { get; set; } = new List<ICareworker>();
}
