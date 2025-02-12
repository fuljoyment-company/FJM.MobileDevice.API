using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

[Index("positionType", Name = "<StockTrend, OrderPosition_PosType,>")]
[Index("article", "positionType", Name = "<StockTrend_OrderPositions_article, Analytics,>")]
[Index("order", Name = "_dta_index_OrderPositions_6_2012690368__K2_1_3_4_5_6_7_8_9_10_11_12_13_14_15_16_17_18_19_20_21_22_23_24_25_26_27_28_29_30_31_")]
[Index("order", "canceled", "article", "position", Name = "_dta_index_OrderPositions_6_2012690368__K2_K4_K3_K12_13_21")]
[Index("canceled", "amountToSend", Name = "man1")]
public partial class OrderPosition
{
    [Key]
    public int id { get; set; }

    public int order { get; set; }

    public int article { get; set; }

    public bool canceled { get; set; }

    public bool transmissionSuccessful { get; set; }

    public bool cancelNotificationSuccessful { get; set; }

    public bool refunded { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? articleID { get; set; }

    public int? bundleId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? bundleItemNumber { get; set; }

    public int? appliedRelevantPromotion { get; set; }

    public int position { get; set; }

    public int quantity { get; set; }

    public int transmittedQuantity { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? fit { get; set; }

    public int? size { get; set; }

    public int? color { get; set; }

    [StringLength(255)]
    public string? additionalData { get; set; }

    [Unicode(false)]
    public string? productOptions { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? giftWrapDescription { get; set; }

    public double? price { get; set; }

    public double? retailPrice { get; set; }

    public double? salePrice { get; set; }

    public bool isPromotion { get; set; }

    public double? promotionPrice { get; set; }

    public double? discountSum { get; set; }

    public int? amountInStock { get; set; }

    public int amountOfScannedArticles { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? shippingDate { get; set; }

    public int amountToSend { get; set; }

    public int amountSended { get; set; }

    public int? picklist { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime lastChange { get; set; }

    [Column(TypeName = "money")]
    public decimal? originalPriceBeforeManualVoucher { get; set; }

    [Column(TypeName = "money")]
    public decimal? costPrice { get; set; }

    [Column(TypeName = "decimal(8, 5)")]
    public decimal? vatRate { get; set; }

    public int? positionType { get; set; }

    public int? firstScanUser { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? firstScanTime { get; set; }

    public bool? reorderingTriggered { get; set; }

    public int? secondScanUser { get; set; }

    public int? vat { get; set; }

    public string? articleDescription { get; set; }

    public double? netPrice { get; set; }

    public double? netRetailPrice { get; set; }

    public int? deliveryCounter { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? autoStorePort { get; set; }

    public bool? packedAtAutostorePort { get; set; }

    [InverseProperty("orderPositionNavigation")]
    public virtual ICollection<OrderPicklistBinLocationReservation> OrderPicklistBinLocationReservations { get; set; } = new List<OrderPicklistBinLocationReservation>();

    [InverseProperty("referencePositionNavigation")]
    public virtual ICollection<OrderReturn> OrderReturns { get; set; } = new List<OrderReturn>();

    [ForeignKey("article")]
    [InverseProperty("OrderPositions")]
    public virtual Article articleNavigation { get; set; } = null!;

    [ForeignKey("color")]
    [InverseProperty("OrderPositions")]
    public virtual ClientColorCode? colorNavigation { get; set; }

    [ForeignKey("firstScanUser")]
    [InverseProperty("OrderPositionfirstScanUserNavigations")]
    public virtual User? firstScanUserNavigation { get; set; }

    [ForeignKey("order")]
    [InverseProperty("OrderPositions")]
    public virtual Order orderNavigation { get; set; } = null!;

    [ForeignKey("picklist")]
    [InverseProperty("OrderPositions")]
    public virtual OrderPicklist? picklistNavigation { get; set; }

    [ForeignKey("secondScanUser")]
    [InverseProperty("OrderPositionsecondScanUserNavigations")]
    public virtual User? secondScanUserNavigation { get; set; }

    [ForeignKey("size")]
    [InverseProperty("OrderPositions")]
    public virtual ClientSize? sizeNavigation { get; set; }
}
