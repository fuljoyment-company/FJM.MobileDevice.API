using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

[Table("Art_x_Delivery")]
[Index("receiptDetailNumber", Name = "NonClusteredIndex-20150729-102900")]
[Index("delivery_id", "art_id", "quantity", Name = "_dta_index_Art_x_Delivery_6_1337875933__K3_K2_K4")]
public partial class Art_x_Delivery
{
    [Key]
    public int id { get; set; }

    public int art_id { get; set; }

    public int delivery_id { get; set; }

    public int quantity { get; set; }

    [StringLength(50)]
    public string? box { get; set; }

    [StringLength(50)]
    public string? palette { get; set; }

    public int? price { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? receiptDetailNumber { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? externIdOne { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? externIdTwo { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? vendorShipmentNo { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? reference1 { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? reference2 { get; set; }

    [InverseProperty("artXDelNavigation")]
    public virtual ICollection<DeliveryReceiptBoxContent> DeliveryReceiptBoxContents { get; set; } = new List<DeliveryReceiptBoxContent>();

    [ForeignKey("art_id")]
    [InverseProperty("Art_x_Deliveries")]
    public virtual Article art { get; set; } = null!;

    [ForeignKey("delivery_id")]
    [InverseProperty("Art_x_Deliveries")]
    public virtual DeliveryReceipt delivery { get; set; } = null!;
}
