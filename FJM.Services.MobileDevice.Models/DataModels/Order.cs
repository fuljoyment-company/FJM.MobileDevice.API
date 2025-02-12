using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

[Index("client", "sandbox", Name = "<Orders-clientSandbox, ReportBestellungen,>")]
[Index("client", "sandbox", "usedShopSystem", Name = "<OrdersMissingIndex, IndexBuilderProposed>")]
[Index("client", "sandbox", "usedShopSystem", "canceled", Name = "<Orders_06012022, IndexBuilderProposed>")]
[Index("sandbox", "canceled", "paymentMethod", "type", "shipmentTrackingNumber", "creationDate", "captureSuccessful", Name = "<Orders_CapturesBeforeShipment, DBEXtCheck,>")]
[Index("processKey", Name = "UQ__Orders__89400C660FB1B4D6", IsUnique = true)]
[Index("client", "creationDate", Name = "_dta_index_Orders_5_2055118512__K2_K64D", IsDescending = new[] { false, true })]
[Index("orderID", "id", "client", Name = "_dta_index_Orders_6_2055118512__K13_K1_K2")]
[Index("client", "invoiceAddress", Name = "_dta_index_Orders_6_2055118512__K2_K39_1")]
[Index("customer", Name = "_dta_index_Orders_6_2055118512__K3")]
[Index("type", "paymentState", "pooledWith", "express01", "packetInlayPrinted", "id", "secondScanSuccessful", "sandbox", "express02", "canceled", Name = "_dta_index_Orders_6_2055118512__K4_K5_K73_K24_K45_K1_K47_K7_K25_K8")]
[Index("pooledWith", Name = "_dta_index_Orders_6_2055118512__K73_1_13")]
[Index("client", "id", "processKey", "orderNumber", "orderID", Name = "_dta_index_Orders_clientAndOrderIdAndOrderNumberAndProcessKey")]
[Index("paymentState", "sandbox", "canceled", "type", "wishedShippingDate", Name = "manualIndexOrders1")]
[Index("client", "paymentState", "sandbox", "canceled", "type", "parcelService", "wishedShippingDate", Name = "sp_Reports_Warehouse_OpenOrders_Orders")]
[Index("paymentState", "sandbox", "canceled", "parcelService", "wishedShippingDate", Name = "sp_Reports_Warehouse_OpenOrders_Orders1")]
public partial class Order
{
    [Key]
    public int id { get; set; }

    public int client { get; set; }

    public int customer { get; set; }

    public int type { get; set; }

    public int paymentState { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string language { get; set; } = null!;

    public bool sandbox { get; set; }

    public bool canceled { get; set; }

    public bool addressCheckSuccessful { get; set; }

    public bool customerVerified { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? ipAddress { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string processKey { get; set; } = null!;

    [StringLength(32)]
    [Unicode(false)]
    public string orderID { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string orderNumber { get; set; } = null!;

    [Column(TypeName = "smalldatetime")]
    public DateTime orderDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? shippingDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? invoiceDate { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? shippingFee { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? giftWrapFee { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? discountValue { get; set; }

    public bool voucherIncludedInPositions { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? paymentServicePartnerFee { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? vatValue { get; set; }

    public bool express01 { get; set; }

    public bool express02 { get; set; }

    public int parcelService { get; set; }

    public double? valueOfGoods { get; set; }

    public double value { get; set; }

    public double grossValue { get; set; }

    public int vat { get; set; }

    public int currency { get; set; }

    [Column(TypeName = "numeric(18, 4)")]
    public decimal? exchangeRate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? exchangeRateDate { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? deliveryRemarks { get; set; }

    [StringLength(5000)]
    [Unicode(false)]
    public string? referer { get; set; }

    public int paymentMethod { get; set; }

    public int? paymentTerms { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? noteDeliveryPickup { get; set; }

    public int invoiceAddress { get; set; }

    public int deliveryAddress { get; set; }

    public bool transmissionSuccessful { get; set; }

    public bool orderNotificationSuccessful { get; set; }

    public bool paymentReminderSent { get; set; }

    public bool boxLabelPrinted { get; set; }

    public bool packetInlayPrinted { get; set; }

    public bool firstScanSuccessful { get; set; }

    public bool secondScanSuccessful { get; set; }

    public bool shippingLabelPrinted { get; set; }

    public bool shippingNotificationSuccessful { get; set; }

    public bool paid { get; set; }

    public double amountPaid { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? dateOfPayment { get; set; }

    public bool returnedGoods { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? returnThresholdValue { get; set; }

    public int notificationRetries { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string? returnCode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? shipmentTrackingNumber { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? shipmentReturnNumber { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? F01 { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? F02 { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? F03 { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? F04 { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? F05 { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime creationDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime lastChange { get; set; }

    public int user { get; set; }

    public DateOnly? wishedShippingDate { get; set; }

    public int? orderPartAmount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PrePaymentPaidDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? shippingArrivedDate { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? shippingInfos { get; set; }

    public int? usedShopSystem { get; set; }

    public int? pooledWith { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? shippingArrivedFirstTry { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? ServiceCenterHint { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? ReturnHint { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? AccountingHint { get; set; }

    public bool wasExportedToAccounting { get; set; }

    public int? senderInfo { get; set; }

    public int? senderAddress { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? firstScanTime { get; set; }

    public int? rootOrder { get; set; }

    public int? orderGroup { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? thirdScan { get; set; }

    public int? thirdScanUser { get; set; }

    public int? channelId { get; set; }

    public int? customsPallet { get; set; }

    public int? pickingType { get; set; }

    public bool? captureSuccessful { get; set; }

    public int? clientShopId { get; set; }

    public int? customerType { get; set; }

    public int? posType { get; set; }

    [InverseProperty("orderNavigation")]
    public virtual ICollection<ArticleSwap> ArticleSwaps { get; set; } = new List<ArticleSwap>();

    [InverseProperty("rootOrderNavigation")]
    public virtual ICollection<Order> InverserootOrderNavigation { get; set; } = new List<Order>();

    [InverseProperty("orderNavigation")]
    public virtual ICollection<OrderPosition> OrderPositions { get; set; } = new List<OrderPosition>();

    [InverseProperty("order")]
    public virtual ICollection<OrderRawDatum> OrderRawData { get; set; } = new List<OrderRawDatum>();

    [InverseProperty("orderNavigation")]
    public virtual ICollection<OrderReturn> OrderReturns { get; set; } = new List<OrderReturn>();

    [InverseProperty("order")]
    public virtual ICollection<StoreBinlocationBox> StoreBinlocationBoxes { get; set; } = new List<StoreBinlocationBox>();

    [ForeignKey("client")]
    [InverseProperty("Orders")]
    public virtual Client clientNavigation { get; set; } = null!;

    [ForeignKey("rootOrder")]
    [InverseProperty("InverserootOrderNavigation")]
    public virtual Order? rootOrderNavigation { get; set; }

    [ForeignKey("thirdScanUser")]
    [InverseProperty("OrderthirdScanUserNavigations")]
    public virtual User? thirdScanUserNavigation { get; set; }

    [ForeignKey("user")]
    [InverseProperty("OrderuserNavigations")]
    public virtual User userNavigation { get; set; } = null!;
}
