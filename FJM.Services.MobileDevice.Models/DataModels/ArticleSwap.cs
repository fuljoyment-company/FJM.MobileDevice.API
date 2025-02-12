using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

[Table("ArticleSwap")]
[Index("active", "reason", "article", Name = "_dta_index_ArticleSwap_6_1763537366__K2_K7_K4_6")]
[Index("article", Name = "_dta_index_ArticleSwap_6_1763537366__K4_1_2_3_5_6_7_8_9_10_11_12_13_14_15")]
public partial class ArticleSwap
{
    [Key]
    public int id { get; set; }

    public bool active { get; set; }

    public bool articleAmountReduced { get; set; }

    public int article { get; set; }

    public int type { get; set; }

    public int quantity { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? reason { get; set; }

    public int? order { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? F01 { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? F02 { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? F03 { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime creationDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? estimatedReturnDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime returnDate { get; set; }

    public int user { get; set; }

    public int? swapHeader { get; set; }

    public int? picklist { get; set; }

    public bool? articleAvailable { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? B2BorderDetails { get; set; }

    [InverseProperty("articleSwapNavigation")]
    public virtual ICollection<OrderPicklistBinLocationReservation> OrderPicklistBinLocationReservations { get; set; } = new List<OrderPicklistBinLocationReservation>();

    [ForeignKey("article")]
    [InverseProperty("ArticleSwaps")]
    public virtual Article articleNavigation { get; set; } = null!;

    [ForeignKey("order")]
    [InverseProperty("ArticleSwaps")]
    public virtual Order? orderNavigation { get; set; }

    [ForeignKey("picklist")]
    [InverseProperty("ArticleSwaps")]
    public virtual OrderPicklist? picklistNavigation { get; set; }

    [ForeignKey("user")]
    [InverseProperty("ArticleSwaps")]
    public virtual User userNavigation { get; set; } = null!;
}
