using System;
using System.Collections.Generic;

namespace stcokManagement.Models;

public partial class TblCase
{
    public int Id { get; set; }

    public int? CaseNo { get; set; }

    public int? SelfId { get; set; }

    public virtual TblSelf? Self { get; set; }

    public virtual ICollection<TblProduct> TblProducts { get; } = new List<TblProduct>();
}
