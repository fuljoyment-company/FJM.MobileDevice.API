using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

[Index("creationDate", Name = "<AlleBestellungn_OrderReturns_creationDate, Berichtmanager,>")]
[Index("articleCancelation", "shopUpdateSuccessful", Name = "<MissingIndex, IndexBuilderproposed>")]
[Index("article", "articleCancelation", Name = "<StockTrend_HBH_OrderReturns_article, ReportServer,>")]
[Index("returnedArticle", "creationDate", Name = "<StockTrend_OrderReturns_returnedArticles, Analytics,>")]
[Index("order", "creationDate", Name = "_dta_index_OrderReturns_6_511444996__K2_K38_1_3_4_5_6_7_8_9_10_11_12_13_14_15_16_17_18_19_20_21_22_23_24_25_26_27_28_29_30_31_")]
[Index("order", "article", "id", Name = "_dta_index_OrderReturns_6_511444996__K2_K3_K1_4_5_6_7_8_9_10_11_12_13_14_15_16_17_18_19_20_21_22_23_24_25_26_27_28_29_30_31_32_")]
[Index("order", "size", "article", "color", Name = "_dta_index_OrderReturns_6_511444996__K2_K9_K3_K10_1_4_6_7_12_19_20_37_38_42")]
[Index("creationDate", "articleCancelation", "notificationSent", "referencePosition", "article", "order", Name = "_dta_index_OrderReturns_6_511444996__K38_K20_K17_K4_K3_K2_37")]
[Index("articleCancelation", "finished", Name = "man2")]
public partial class OrderReturn
{
    [Key]
    public int id { get; set; }

    public int order { get; set; }

    public int article { get; set; }

    public int referencePosition { get; set; }

    public bool isComplaint { get; set; }

    public int position { get; set; }

    public int quantity { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? fit { get; set; }

    public int? size { get; set; }

    public int? color { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? additionalData { get; set; }

    public double price { get; set; }

    public double? salePrice { get; set; }

    public int amountOfScannedArticles { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string? returnBarcode { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? reason { get; set; }

    public bool notificationSent { get; set; }

    public bool articleReplacement { get; set; }

    public bool articleChange { get; set; }

    public bool articleCancelation { get; set; }

    public bool articleDamaged { get; set; }

    public bool wrongAddress { get; set; }

    public bool articleUsed { get; set; }

    public bool articleSellable { get; set; }

    public bool returnComplete { get; set; }

    public bool reasonSizeCollectionOrdered { get; set; }

    public bool reasonArticleDidntAppeal { get; set; }

    public bool reasonArticleDidntMatchDescription { get; set; }

    public bool reasonRoomy { get; set; }

    public bool reasonClose { get; set; }

    public bool reasonArticleDamaged { get; set; }

    public bool reasonWrongArticle { get; set; }

    public bool reasonDeliveryIsLate { get; set; }

    public bool reasonOther { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? reasonOtherDescription { get; set; }

    public bool reasonNotStated { get; set; }

    public bool finished { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime creationDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime lastChange { get; set; }

    public int user { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? shippingDate { get; set; }

    public int? picklist { get; set; }

    public int? wronglyShippedArticleId { get; set; }

    public int returnedArticle { get; set; }

    public int? changedArticle { get; set; }

    public int returnReason { get; set; }

    public int? swapReason { get; set; }

    public int? parcelService { get; set; }

    public int? amountSended { get; set; }

    public bool shopUpdateSuccessful { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? firstScanTime { get; set; }

    public int? firstScanUser { get; set; }

    public string? articleDescription { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? autoStorePort { get; set; }

    public bool? packedAtAutostorePort { get; set; }

    [InverseProperty("orderReturnNavigation")]
    public virtual ICollection<OrderPicklistBinLocationReservation> OrderPicklistBinLocationReservations { get; set; } = new List<OrderPicklistBinLocationReservation>();

    [ForeignKey("article")]
    [InverseProperty("OrderReturnarticleNavigations")]
    public virtual Article articleNavigation { get; set; } = null!;

    [ForeignKey("changedArticle")]
    [InverseProperty("OrderReturnchangedArticleNavigations")]
    public virtual Article? changedArticleNavigation { get; set; }

    [ForeignKey("color")]
    [InverseProperty("OrderReturns")]
    public virtual ClientColorCode? colorNavigation { get; set; }

    [ForeignKey("firstScanUser")]
    [InverseProperty("OrderReturnfirstScanUserNavigations")]
    public virtual User? firstScanUserNavigation { get; set; }

    [ForeignKey("order")]
    [InverseProperty("OrderReturns")]
    public virtual Order orderNavigation { get; set; } = null!;

    [ForeignKey("picklist")]
    [InverseProperty("OrderReturns")]
    public virtual OrderPicklist? picklistNavigation { get; set; }

    [ForeignKey("referencePosition")]
    [InverseProperty("OrderReturns")]
    public virtual OrderPosition referencePositionNavigation { get; set; } = null!;

    [ForeignKey("returnedArticle")]
    [InverseProperty("OrderReturnreturnedArticleNavigations")]
    public virtual Article returnedArticleNavigation { get; set; } = null!;

    [ForeignKey("size")]
    [InverseProperty("OrderReturns")]
    public virtual ClientSize? sizeNavigation { get; set; }

    [ForeignKey("user")]
    [InverseProperty("OrderReturnuserNavigations")]
    public virtual User userNavigation { get; set; } = null!;

    [ForeignKey("wronglyShippedArticleId")]
    [InverseProperty("OrderReturnwronglyShippedArticles")]
    public virtual Article? wronglyShippedArticle { get; set; }
}
