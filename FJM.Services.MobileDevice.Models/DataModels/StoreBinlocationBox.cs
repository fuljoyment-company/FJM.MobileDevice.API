using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

public partial class StoreBinlocationBox
{
    [Key]
    public int id { get; set; }

    public int? binLocationID { get; set; }

    public int? partnerStoreID { get; set; }

    public int? orderID { get; set; }

    [ForeignKey("binLocationID")]
    [InverseProperty("StoreBinlocationBoxes")]
    public virtual BinLocationReference? binLocation { get; set; }

    [ForeignKey("orderID")]
    [InverseProperty("StoreBinlocationBoxes")]
    public virtual Order? order { get; set; }

    [ForeignKey("partnerStoreID")]
    [InverseProperty("StoreBinlocationBoxes")]
    public virtual PartnerStore? partnerStore { get; set; }
}
