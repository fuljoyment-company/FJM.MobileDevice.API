using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

[Index("orderPosition", "binLocation", "isActive", Name = "<OrderPicklistBinLocationReservations-MissingIndex, MIndexbuilderProposed>")]
public partial class OrderPicklistBinLocationReservation
{
    [Key]
    public int id { get; set; }

    public int? orderPosition { get; set; }

    public int? orderReturn { get; set; }

    public int binLocation { get; set; }

    public int quantity { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime creationDate { get; set; }

    public bool isActive { get; set; }

    public int? articleSwap { get; set; }

    public int? article { get; set; }

    [ForeignKey("article")]
    [InverseProperty("OrderPicklistBinLocationReservations")]
    public virtual Article? articleNavigation { get; set; }

    [ForeignKey("articleSwap")]
    [InverseProperty("OrderPicklistBinLocationReservations")]
    public virtual ArticleSwap? articleSwapNavigation { get; set; }

    [ForeignKey("binLocation")]
    [InverseProperty("OrderPicklistBinLocationReservations")]
    public virtual BinLocationReference binLocationNavigation { get; set; } = null!;

    [ForeignKey("orderPosition")]
    [InverseProperty("OrderPicklistBinLocationReservations")]
    public virtual OrderPosition? orderPositionNavigation { get; set; }

    [ForeignKey("orderReturn")]
    [InverseProperty("OrderPicklistBinLocationReservations")]
    public virtual OrderReturn? orderReturnNavigation { get; set; }
}
