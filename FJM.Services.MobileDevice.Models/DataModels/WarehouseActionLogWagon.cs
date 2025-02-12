using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

[Table("WarehouseActionLogWagon")]
public partial class WarehouseActionLogWagon
{
    [Key]
    public int id { get; set; }

    public int type { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime creationDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? finishDate { get; set; }

    [InverseProperty("wagonNavigation")]
    public virtual ICollection<WarehouseActionLog> WarehouseActionLogs { get; set; } = new List<WarehouseActionLog>();
}
