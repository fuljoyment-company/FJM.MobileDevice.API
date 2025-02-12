using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

[Table("WarehouseActionLog")]
[Index("article", Name = "<WarehouseActionLog_06012022, IndexBuilderProposed>")]
[Index("isActive", "wagon", "type", Name = "<WarehouseActionLog_06012022, IndexProposer>")]
[Index("isActive", "success", "finished", "article", "reason", Name = "_dta_index_WarehouseActionLog_6_1255115662__K14_K7_K9_K4_K6_5")]
[Index("type", "isActive", Name = "warehouseactiologIndex")]
[Index("type", "isActive", "reason", "lastChange", Name = "warehouseactiologIndex1")]
public partial class WarehouseActionLog
{
    [Key]
    public int id { get; set; }

    public int type { get; set; }

    public int warehouse { get; set; }

    public int article { get; set; }

    public int quantity { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? reason { get; set; }

    public bool success { get; set; }

    public int? binLocation { get; set; }

    public bool? finished { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime lastChange { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime creationDate { get; set; }

    public int user { get; set; }

    public int? userPC { get; set; }

    public bool isActive { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? returnDate { get; set; }

    public int? deliveryReceipt { get; set; }

    public int? wagon { get; set; }

    public int? lot { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? deliveryDate { get; set; }

    public int? deliveryKind { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? portName { get; set; }

    public int? autoStoreBin { get; set; }

    [ForeignKey("article")]
    [InverseProperty("WarehouseActionLogs")]
    public virtual Article articleNavigation { get; set; } = null!;

    [ForeignKey("binLocation")]
    [InverseProperty("WarehouseActionLogs")]
    public virtual BinLocationReference? binLocationNavigation { get; set; }

    [ForeignKey("deliveryReceipt")]
    [InverseProperty("WarehouseActionLogs")]
    public virtual DeliveryReceipt? deliveryReceiptNavigation { get; set; }

    [ForeignKey("lot")]
    [InverseProperty("WarehouseActionLogs")]
    public virtual WarehouseActionLogLot? lotNavigation { get; set; }

    [ForeignKey("user")]
    [InverseProperty("WarehouseActionLogs")]
    public virtual User userNavigation { get; set; } = null!;

    [ForeignKey("wagon")]
    [InverseProperty("WarehouseActionLogs")]
    public virtual WarehouseActionLogWagon? wagonNavigation { get; set; }

    [ForeignKey("warehouse")]
    [InverseProperty("WarehouseActionLogs")]
    public virtual Warehouse warehouseNavigation { get; set; } = null!;
}
