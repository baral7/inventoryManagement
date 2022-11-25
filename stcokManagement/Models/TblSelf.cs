using System;
using System.Collections.Generic;

namespace stcokManagement.Models;

public partial class TblSelf
{
    public int Id { get; set; }

    public int? SelfNo { get; set; }

    public string? AirlineName { get; set; }

    public int? BlockNo { get; set; }

    public virtual ICollection<TblCase> TblCases { get; } = new List<TblCase>();
}
