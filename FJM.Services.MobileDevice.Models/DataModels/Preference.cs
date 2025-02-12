using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

public partial class Preference
{
    [Key]
    public int id { get; set; }

    public int client { get; set; }

    public int customerStartNumber { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string clientNumberFormat { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string orderNumberFormat { get; set; } = null!;

    public int orderNumberStart { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string shippingNumberFormat { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string invoiceNumberFormat { get; set; } = null!;

    public bool sendOrderNotification { get; set; }

    public bool sendShippingNotification { get; set; }

    public int maxRetriesNotification { get; set; }

    public int retriesTimeSpanMinutes { get; set; }

    public int defaultCulture { get; set; }

    public int defaultCurrency { get; set; }

    public int defaultVAT { get; set; }

    public int defaultPacketMeasurements { get; set; }

    public int defaultParcelService { get; set; }

    public int expressParcelService { get; set; }

    public int defaultDHLProductCode { get; set; }

    public int reservationTimeToLiveMinutes { get; set; }

    public bool automaticPrinting { get; set; }

    public bool usePacketMeasurements { get; set; }

    public int reminderOfPaymentDays { get; set; }

    public int cancellationOfOrderDays { get; set; }

    public bool isImageMandatory { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string databaseInformationMark { get; set; } = null!;

    [StringLength(2)]
    [Unicode(false)]
    public string rowMark { get; set; } = null!;

    [StringLength(2)]
    [Unicode(false)]
    public string attributeSeparator { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string? exportOutputPath { get; set; }

    public bool isFtpPath { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? accountingsOutputPath { get; set; }

    public bool isFtpPathAccountings { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? accountingsCredentialsUsername { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? accountingsCredentialsPassword { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? exportCredentialsUsername { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? exportCredentialsPassword { get; set; }

    public bool separateBankAccountForOrder { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? bankBalancePath { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? sepaFilePath { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal? prepaymentShippingThreshold { get; set; }

    public int reorderDays { get; set; }

    public bool concatPositions { get; set; }

    public TimeOnly? shippingNotificationTime { get; set; }

    public TimeOnly? paymentProviderNotificationTime { get; set; }

    public bool useSuppliedParcelService { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime creationDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime lastChange { get; set; }

    public int user { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? imageMainShopPath { get; set; }

    public int StockRemovalArticleScanCount { get; set; }

    public bool? allowFor24hExchangeOfReturn { get; set; }

    public bool? addProcessingHint { get; set; }

    public bool? noDeliveryDifferences { get; set; }

    public bool? saveArticleSettings { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? lastSMS { get; set; }

    public bool? noDeliveryAmountDifferences { get; set; }

    public int? maxAmountOfPosInPicklist { get; set; }

    public bool? activeForAccounting { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal? shippingCostRefundThreshold { get; set; }

    public bool sendSMS { get; set; }

    public bool allowChanges { get; set; }

    public int amountOfBinsForDefectArticles { get; set; }

    public int? reorderSequenceNumber { get; set; }

    public int? picklistProcessingType { get; set; }

    public bool onlyB2B { get; set; }

    public int amountOrdersInMFP { get; set; }

    public bool? forceBinlocationScanforPicking { get; set; }

    public int? maxAmountOfPosInB2BPicklist { get; set; }

    public int? maxAmountB2BOrdersPicklist { get; set; }

    public int? dhlLabelPrintFormat { get; set; }

    public int? B2BBoxlabelType { get; set; }

    public int? coDSequenceNumber { get; set; }

    public bool printLabelForSingleOrders { get; set; }

    [ForeignKey("client")]
    [InverseProperty("Preferences")]
    public virtual Client clientNavigation { get; set; } = null!;
}
