using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

[Index("articleID", "orderID", Name = "<OrderRawData_06012022, IndexBuilderProposed>")]
public partial class OrderRawDatum
{
    [Key]
    public int id { get; set; }

    public int articleID { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime orderDate { get; set; }

    public int amount { get; set; }

    public double? storePrice { get; set; }

    public int partnerStoreID { get; set; }

    public int? orderID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? tour { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime creationDate { get; set; }

    public double? GLN { get; set; }

    public double? GLN_2 { get; set; }

    public bool? expressOrder { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? extern_orderId { get; set; }

    public int orderType { get; set; }

    public int firstScan { get; set; }

    public int secondScan { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PO_number { get; set; }

    public int? wagonID { get; set; }

    public int? picklistID { get; set; }

    public int? totalQuantity { get; set; }

    [ForeignKey("articleID")]
    [InverseProperty("OrderRawData")]
    public virtual Article article { get; set; } = null!;

    [ForeignKey("orderID")]
    [InverseProperty("OrderRawData")]
    public virtual Order? order { get; set; }

    [ForeignKey("partnerStoreID")]
    [InverseProperty("OrderRawData")]
    public virtual PartnerStore partnerStore { get; set; } = null!;
}
