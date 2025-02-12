using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

[Table("DeliveryReceiptBoxContent")]
public partial class DeliveryReceiptBoxContent
{
    [Key]
    public int id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string boxNumber { get; set; } = null!;

    public int artXDel { get; set; }

    public int receiptAmount { get; set; }

    public int sendetAmount { get; set; }

    public int? storedInStockLocation { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime creationDate { get; set; }

    public int user { get; set; }

    [ForeignKey("artXDel")]
    [InverseProperty("DeliveryReceiptBoxContents")]
    public virtual Art_x_Delivery artXDelNavigation { get; set; } = null!;

    [ForeignKey("storedInStockLocation")]
    [InverseProperty("DeliveryReceiptBoxContents")]
    public virtual BinLocationReference? storedInStockLocationNavigation { get; set; }

    [ForeignKey("user")]
    [InverseProperty("DeliveryReceiptBoxContents")]
    public virtual User userNavigation { get; set; } = null!;
}
