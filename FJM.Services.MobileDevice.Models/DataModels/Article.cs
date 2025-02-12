using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

[Index("client", Name = "<Articles_06012022, IndexBuilderProposed>")]
[Index("client", Name = "<StockTrend_Articles_Client, Analytics,>")]
[Index("id", "vatRate", "colorID", "size", Name = "_dta_index_Articles_6_777209969__K1_K24_K12_K14_3_6_7_18_20_22_25_32_53")]
[Index("client", "id", "productLine", "isActive", "sellable", "eanCode", "articleNumber", "additionalItemCode", "amount", "amountReserved", "amountProcessing", "colorID", "fit", "size", "lengthInCm", "widthInCm", Name = "_dta_index_Articles_6_777209969__K2_K1_K3_K4_K5_K6_K7_K8_K9_K10_K11_K12_K13_K14_K15_K16_17_18_19_20_21_22_23_24_25_26_27_28_29_")]
[Index("client", "id", "sellable", "isActive", "lastChange", Name = "_dta_index_Articles_6_777209969__K2_K1_K5_K4_K39_6_7_8_9_10")]
[Index("eanCode", "client", "id", Name = "_dta_index_Articles_6_777209969__K6_K2_K1_3_4_5_7_8_9_10_11_12_13_14_15_16_17_18_19_20_21_22_23_24_25_26_27_28_29_30_31_32_33_")]
public partial class Article
{
    [Key]
    public int id { get; set; }

    public int client { get; set; }

    public int productLine { get; set; }

    public bool isActive { get; set; }

    public bool sellable { get; set; }

    [StringLength(13)]
    [Unicode(false)]
    public string eanCode { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? articleNumber { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? additionalItemCode { get; set; }

    public int amount { get; set; }

    public int amountReserved { get; set; }

    public int amountProcessing { get; set; }

    public int? colorID { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? fit { get; set; }

    public int? size { get; set; }

    public int? lengthInCm { get; set; }

    public int? widthInCm { get; set; }

    public int? heightInCm { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? weightInG { get; set; }

    public int? customsInformation { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? description { get; set; }

    [StringLength(4000)]
    public string? fullDescription { get; set; }

    public double? price { get; set; }

    public double? costPrice { get; set; }

    public int vatRate { get; set; }

    [StringLength(512)]
    [Unicode(false)]
    public string? pathToImage { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? F01 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? F02 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? F03 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? F04 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? F05 { get; set; }

    public int minPurchaseUnits { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? recommendedRetailPrice { get; set; }

    public bool isExpireDateRequired { get; set; }

    public bool isOtcDrug { get; set; }

    public bool isVoucher { get; set; }

    public int? internArticleNumber { get; set; }

    public int? distributor { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime creationDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime lastChange { get; set; }

    public int user { get; set; }

    public int reOrderBorder { get; set; }

    public bool RestrictedAccess { get; set; }

    public int? producer { get; set; }

    public int? contentUnit { get; set; }

    public int? content { get; set; }

    public bool isOptional { get; set; }

    public bool isReturnable { get; set; }

    public bool skipScan { get; set; }

    [StringLength(500)]
    public string? composition { get; set; }

    [StringLength(200)]
    public string? quality { get; set; }

    [StringLength(500)]
    public string? qualityDescription { get; set; }

    public int? style { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? season { get; set; }

    [StringLength(200)]
    public string? title { get; set; }

    [StringLength(250)]
    public string? hintWhileStoring { get; set; }

    public bool isImageRequired { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? imagePath2 { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? imagePath3 { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? imagePath4 { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? imagePath5 { get; set; }

    public bool skipStorageScan { get; set; }

    public bool wasTransmittedToShop { get; set; }

    public int? articleSetting { get; set; }

    public int? purchasedAmount { get; set; }

    public int? producingCountry { get; set; }

    [StringLength(500)]
    public string? returnHint { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? variantCode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? manufacturerIdentificationCode { get; set; }

    public int? brand { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? barcode { get; set; }

    public bool bestSeller { get; set; }

    public int? amountInMainWarehouse { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? weightDate { get; set; }

    public int amountTransfer { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? articleNumberSecond { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? dispatchType { get; set; }

    [InverseProperty("art")]
    public virtual ICollection<Art_x_Bin> Art_x_Bins { get; set; } = new List<Art_x_Bin>();

    [InverseProperty("art")]
    public virtual ICollection<Art_x_Delivery> Art_x_Deliveries { get; set; } = new List<Art_x_Delivery>();

    [InverseProperty("art")]
    public virtual ICollection<Art_x_DistrOrder> Art_x_DistrOrders { get; set; } = new List<Art_x_DistrOrder>();

    [InverseProperty("composedProductNavigation")]
    public virtual ICollection<ArticleComposition> ArticleCompositioncomposedProductNavigations { get; set; } = new List<ArticleComposition>();

    [InverseProperty("compositionLineProductNavigation")]
    public virtual ICollection<ArticleComposition> ArticleCompositioncompositionLineProductNavigations { get; set; } = new List<ArticleComposition>();

    [InverseProperty("articleNavigation")]
    public virtual ICollection<ArticleSwap> ArticleSwaps { get; set; } = new List<ArticleSwap>();

    [InverseProperty("articleNavigation")]
    public virtual ICollection<BinLocationReference> BinLocationReferences { get; set; } = new List<BinLocationReference>();

    [InverseProperty("article")]
    public virtual ICollection<InventoryDifference> InventoryDifferences { get; set; } = new List<InventoryDifference>();

    [InverseProperty("articleNavigation")]
    public virtual ICollection<OrderPicklistBinLocationReservation> OrderPicklistBinLocationReservations { get; set; } = new List<OrderPicklistBinLocationReservation>();

    [InverseProperty("articleNavigation")]
    public virtual ICollection<OrderPosition> OrderPositions { get; set; } = new List<OrderPosition>();

    [InverseProperty("article")]
    public virtual ICollection<OrderRawDatum> OrderRawData { get; set; } = new List<OrderRawDatum>();

    [InverseProperty("articleNavigation")]
    public virtual ICollection<OrderReturn> OrderReturnarticleNavigations { get; set; } = new List<OrderReturn>();

    [InverseProperty("changedArticleNavigation")]
    public virtual ICollection<OrderReturn> OrderReturnchangedArticleNavigations { get; set; } = new List<OrderReturn>();

    [InverseProperty("returnedArticleNavigation")]
    public virtual ICollection<OrderReturn> OrderReturnreturnedArticleNavigations { get; set; } = new List<OrderReturn>();

    [InverseProperty("wronglyShippedArticle")]
    public virtual ICollection<OrderReturn> OrderReturnwronglyShippedArticles { get; set; } = new List<OrderReturn>();

    [InverseProperty("articleNavigation")]
    public virtual ICollection<WarehouseActionLog> WarehouseActionLogs { get; set; } = new List<WarehouseActionLog>();

    [ForeignKey("client")]
    [InverseProperty("Articles")]
    public virtual Client clientNavigation { get; set; } = null!;

    [ForeignKey("colorID")]
    [InverseProperty("Articles")]
    public virtual ClientColorCode? color { get; set; }

    [ForeignKey("size")]
    [InverseProperty("Articles")]
    public virtual ClientSize? sizeNavigation { get; set; }
}
