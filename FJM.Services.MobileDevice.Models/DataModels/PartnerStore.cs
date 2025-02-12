using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

public partial class PartnerStore
{
    [Key]
    public int id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string storeId { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? name { get; set; }

    public int client { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? tour { get; set; }

    public double? GLN { get; set; }

    public double? GLN2 { get; set; }

    public bool isActive { get; set; }

    public int? salesChannel { get; set; }

    public bool isDeleted { get; set; }

    [InverseProperty("partnerStore")]
    public virtual ICollection<OrderRawDatum> OrderRawData { get; set; } = new List<OrderRawDatum>();

    [InverseProperty("partnerStore")]
    public virtual ICollection<StoreBinlocationBox> StoreBinlocationBoxes { get; set; } = new List<StoreBinlocationBox>();

    [ForeignKey("client")]
    [InverseProperty("PartnerStores")]
    public virtual Client clientNavigation { get; set; } = null!;
}
