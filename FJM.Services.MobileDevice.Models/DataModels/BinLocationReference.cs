using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

[Index("warehouseReference", "active", "canBeMultiple", Name = "<Binlocation_060120211302, QueryOptimizerProposed,>")]
[Index("pointerToBinReference", Name = "_dta_index_BinLocationReferences_6_2091258605__K10_4_15")]
[Index("article", Name = "_dta_index_BinLocationReferences_6_2091258605__K2_1_3_4_5_6_7_8_9_10_11_12_13_14_15_16_17_18_19_20_21")]
public partial class BinLocationReference
{
    [Key]
    public int id { get; set; }

    public int article { get; set; }

    public int? warehouseReference { get; set; }

    public int shelfReference { get; set; }

    public int columnReference { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string? rowReference { get; set; }

    public int binLocationSize { get; set; }

    public bool active { get; set; }

    public bool reserved { get; set; }

    public int pointerToBinReference { get; set; }

    public int declaredGoods { get; set; }

    public int storedGoods { get; set; }

    public DateOnly? dateOfExpiry { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? batchNumber { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string? area { get; set; }

    public bool canBeMultiple { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? palette { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime changed_at { get; set; }

    public int changed_by { get; set; }

    public bool unclean { get; set; }

    public int? storageArea { get; set; }

    [InverseProperty("bin")]
    public virtual ICollection<Art_x_Bin> Art_x_Bins { get; set; } = new List<Art_x_Bin>();

    [InverseProperty("bin")]
    public virtual ICollection<BinsPalette> BinsPalettes { get; set; } = new List<BinsPalette>();

    [InverseProperty("storedInStockLocationNavigation")]
    public virtual ICollection<DeliveryReceiptBoxContent> DeliveryReceiptBoxContents { get; set; } = new List<DeliveryReceiptBoxContent>();

    [InverseProperty("bin")]
    public virtual ICollection<InventoryScanDetail> InventoryScanDetails { get; set; } = new List<InventoryScanDetail>();

    [InverseProperty("binLocationNavigation")]
    public virtual ICollection<OrderPicklistBinLocationReservation> OrderPicklistBinLocationReservations { get; set; } = new List<OrderPicklistBinLocationReservation>();

    [InverseProperty("binLocation")]
    public virtual ICollection<StoreBinlocationBox> StoreBinlocationBoxes { get; set; } = new List<StoreBinlocationBox>();

    [InverseProperty("binLocationNavigation")]
    public virtual ICollection<WarehouseActionLog> WarehouseActionLogs { get; set; } = new List<WarehouseActionLog>();

    [ForeignKey("article")]
    [InverseProperty("BinLocationReferences")]
    public virtual Article articleNavigation { get; set; } = null!;

    [ForeignKey("warehouseReference")]
    [InverseProperty("BinLocationReferences")]
    public virtual Warehouse? warehouseReferenceNavigation { get; set; }
}
