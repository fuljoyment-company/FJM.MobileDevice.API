using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

[Index("deliveryReceiptNumber", "isOutgoing", Name = "NonClusteredIndex-20150729-103202")]
[Index("type", "id", "deliveryReceiptNumber", "creationDate", Name = "_dta_index_DeliveryReceipts_6_2087782595__K13_K1_K3_K4")]
public partial class DeliveryReceipt
{
    [Key]
    public int id { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? estimatedDeliveryDate { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string deliveryReceiptNumber { get; set; } = null!;

    [Column(TypeName = "smalldatetime")]
    public DateTime creationDate { get; set; }

    public int user_id { get; set; }

    public bool isOutgoing { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? signedDate { get; set; }

    public int? signedUser { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? receiptDetailNumber { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? SecondSignedDate { get; set; }

    public int? SecondSignedUser { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? DeliveryDate { get; set; }

    public int? type { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? vendorNum { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? deliveryType { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? referenceNumber { get; set; }

    public int? client { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? lastModified { get; set; }

    public int? incomingType { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? documentDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? unblockingCode { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? unblockingDate { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? receiptBarcode { get; set; }

    public int? pooledDeliveryReceipt { get; set; }

    [InverseProperty("delivery")]
    public virtual ICollection<Art_x_Delivery> Art_x_Deliveries { get; set; } = new List<Art_x_Delivery>();

    [InverseProperty("deliveryReceiptNavigation")]
    public virtual ICollection<WarehouseActionLog> WarehouseActionLogs { get; set; } = new List<WarehouseActionLog>();

    [ForeignKey("client")]
    [InverseProperty("DeliveryReceipts")]
    public virtual Client? clientNavigation { get; set; }
}
