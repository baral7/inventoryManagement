using System;
using System.Collections.Generic;

namespace stcokManagement.Models;

public partial class TblProduct
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? ArrivealDate { get; set; }

    public string? PickupDate { get; set; }

    public int? TotalQuantity { get; set; }

    public int? PickedQuantity { get; set; }

    public int? SafetyStock { get; set; }

    public int? CaseId { get; set; }

    public virtual TblCase? Case { get; set; }
}
