using System;
using System.Collections.Generic;

namespace iCARE.Models;

public partial class ModificationHistory
{
    public int Id { get; set; }

    public string DocId { get; set; } = null!;

    public DateOnly DatOfModification { get; set; }

    public string Description { get; set; } = null!;

    public string ModifiedByUserId { get; set; } = null!;

    public virtual DocumentMetadatum Doc { get; set; } = null!;

    public virtual ICareuser ModifiedByUser { get; set; } = null!;
}
