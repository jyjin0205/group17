using System;
using System.Collections.Generic;

namespace iCARE.Models;

public partial class UserPassword
{
    public string Id { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string EncryptedPassword { get; set; } = null!;

    public int? PasswordExpiryTime { get; set; }

    public DateOnly? UserAccountExpiryDate { get; set; }

    public virtual ICareuser IdNavigation { get; set; } = null!;
}
