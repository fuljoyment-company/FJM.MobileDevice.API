using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FJM.Services.MobileDevice.Models.DataModels;

public partial class MobileDeviceDbContext : DbContext
{
    public MobileDeviceDbContext()
    {
    }

    public MobileDeviceDbContext(DbContextOptions<MobileDeviceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Art_x_Bin> Art_x_Bins { get; set; }

    public virtual DbSet<Art_x_Delivery> Art_x_Deliveries { get; set; }

    public virtual DbSet<Art_x_DistrOrder> Art_x_DistrOrders { get; set; }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<ArticleComposition> ArticleCompositions { get; set; }

    public virtual DbSet<ArticleSwap> ArticleSwaps { get; set; }

    public virtual DbSet<BinLocationReference> BinLocationReferences { get; set; }

    public virtual DbSet<BinsPalette> BinsPalettes { get; set; }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientColorCode> ClientColorCodes { get; set; }

    public virtual DbSet<ClientSize> ClientSizes { get; set; }

    public virtual DbSet<DeliveryReceipt> DeliveryReceipts { get; set; }

    public virtual DbSet<DeliveryReceiptBoxContent> DeliveryReceiptBoxContents { get; set; }

    public virtual DbSet<GoodsReceived> GoodsReceiveds { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<InventoryDifference> InventoryDifferences { get; set; }

    public virtual DbSet<InventoryScanDetail> InventoryScanDetails { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderPicklist> OrderPicklists { get; set; }

    public virtual DbSet<OrderPicklistBinLocationReservation> OrderPicklistBinLocationReservations { get; set; }

    public virtual DbSet<OrderPosition> OrderPositions { get; set; }

    public virtual DbSet<OrderRawDatum> OrderRawData { get; set; }

    public virtual DbSet<OrderReturn> OrderReturns { get; set; }

    public virtual DbSet<OrderStatusChange> OrderStatusChanges { get; set; }

    public virtual DbSet<OrderTransactionReference> OrderTransactionReferences { get; set; }

    public virtual DbSet<PartnerStore> PartnerStores { get; set; }

    public virtual DbSet<Preference> Preferences { get; set; }

    public virtual DbSet<ProcessCost> ProcessCosts { get; set; }

    public virtual DbSet<ProcessTime> ProcessTimes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<ScheduledShippingNotificationDeployment> ScheduledShippingNotificationDeployments { get; set; }

    public virtual DbSet<StoreBinlocationBox> StoreBinlocationBoxes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<WarehouseActionLog> WarehouseActionLogs { get; set; }

    public virtual DbSet<WarehouseActionLogLot> WarehouseActionLogLots { get; set; }

    public virtual DbSet<WarehouseActionLogWagon> WarehouseActionLogWagons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=dx292-sd.fuljoyment.com;initial catalog=fjm_fulfillment_replication;user id=dev_gopi;password=6d0VInym4SOjKoRpQ9Nc;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Art_x_Bin>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Art_X_Bin");

            entity.HasOne(d => d.art).WithMany(p => p.Art_x_Bins)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Art_X_Bin_Articles");

            entity.HasOne(d => d.bin).WithMany(p => p.Art_x_Bins)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Art_X_Bin_BinLocationReferences");

            entity.HasOne(d => d.userNavigation).WithMany(p => p.Art_x_Bins)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Art_x_Bin_Users");
        });

        modelBuilder.Entity<Art_x_Delivery>(entity =>
        {
            entity.HasOne(d => d.art).WithMany(p => p.Art_x_Deliveries).HasConstraintName("FK_Art_x_Delivery_Articles");

            entity.HasOne(d => d.delivery).WithMany(p => p.Art_x_Deliveries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Art_x_Delivery_DeliveryReceipts");
        });

        modelBuilder.Entity<Art_x_DistrOrder>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Art_X_DistrOrders");

            entity.HasOne(d => d.art).WithMany(p => p.Art_x_DistrOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Art_X_DistrOrders_Articles");
        });

        modelBuilder.Entity<Article>(entity =>
        {
            entity.Property(e => e.eanCode).IsFixedLength();
            entity.Property(e => e.returnHint).IsFixedLength();

            entity.HasOne(d => d.clientNavigation).WithMany(p => p.Articles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Articles_Clients");

            entity.HasOne(d => d.color).WithMany(p => p.Articles).HasConstraintName("FK_Articles_ClientColorCodes");

            entity.HasOne(d => d.sizeNavigation).WithMany(p => p.Articles).HasConstraintName("FK_Articles_ClientSizes");
        });

        modelBuilder.Entity<ArticleComposition>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__ArticleC__3213E83FA24F9389");

            entity.HasOne(d => d.composedProductNavigation).WithMany(p => p.ArticleCompositioncomposedProductNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArticleCompositions_ToComposedArticle");

            entity.HasOne(d => d.compositionLineProductNavigation).WithMany(p => p.ArticleCompositioncompositionLineProductNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArticleCompositions_ToCompositionArticle");
        });

        modelBuilder.Entity<ArticleSwap>(entity =>
        {
            entity.HasOne(d => d.articleNavigation).WithMany(p => p.ArticleSwaps).HasConstraintName("FK_ArticleSwap_Articles");

            entity.HasOne(d => d.orderNavigation).WithMany(p => p.ArticleSwaps)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ArticleSwap_Orders");

            entity.HasOne(d => d.picklistNavigation).WithMany(p => p.ArticleSwaps).HasConstraintName("fk");

            entity.HasOne(d => d.userNavigation).WithMany(p => p.ArticleSwaps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArticleSwap_Users");
        });

        modelBuilder.Entity<BinLocationReference>(entity =>
        {
            entity.HasOne(d => d.articleNavigation).WithMany(p => p.BinLocationReferences).HasConstraintName("FK_BinLocationReferences_Articles");

            entity.HasOne(d => d.warehouseReferenceNavigation).WithMany(p => p.BinLocationReferences).HasConstraintName("FK_BinLocationReferences_Warehouses");
        });

        modelBuilder.Entity<BinsPalette>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_PalletteBins");

            entity.HasOne(d => d.bin).WithMany(p => p.BinsPalettes).HasConstraintName("FK_PalletteBins_BinLocationReferences");

            entity.HasOne(d => d.userNavigation).WithMany(p => p.BinsPalettes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PalletteBins_Users");
        });

        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasOne(d => d.userNavigation).WithMany(p => p.Branches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Branches_Users");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasOne(d => d.userNavigation).WithMany(p => p.Clients)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clients_Users");
        });

        modelBuilder.Entity<ClientColorCode>(entity =>
        {
            entity.HasOne(d => d.clientNavigation).WithMany(p => p.ClientColorCodes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientColorCodes_Clients");
        });

        modelBuilder.Entity<ClientSize>(entity =>
        {
            entity.HasOne(d => d.clientNavigation).WithMany(p => p.ClientSizes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientSizes_Clients");

            entity.HasOne(d => d.userNavigation).WithMany(p => p.ClientSizes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientSizes_Users");
        });

        modelBuilder.Entity<DeliveryReceipt>(entity =>
        {
            entity.HasOne(d => d.clientNavigation).WithMany(p => p.DeliveryReceipts).HasConstraintName("FK__DeliveryR__clien__71F5DC55");
        });

        modelBuilder.Entity<DeliveryReceiptBoxContent>(entity =>
        {
            entity.HasOne(d => d.artXDelNavigation).WithMany(p => p.DeliveryReceiptBoxContents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DeliveryReceiptBoxContent_Art_x_Delivery");

            entity.HasOne(d => d.storedInStockLocationNavigation).WithMany(p => p.DeliveryReceiptBoxContents).HasConstraintName("FK_DeliveryReceiptBoxContent_BinLocationReferences");

            entity.HasOne(d => d.userNavigation).WithMany(p => p.DeliveryReceiptBoxContents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DeliveryReceiptBoxContent_Users");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasOne(d => d.clientNavigation).WithMany(p => p.Inventories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_Clients");
        });

        modelBuilder.Entity<InventoryDifference>(entity =>
        {
            entity.HasOne(d => d.article).WithMany(p => p.InventoryDifferences)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryDifferences_Articles");

            entity.HasOne(d => d.inventoryScan).WithMany(p => p.InventoryDifferences)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryDifferences_InventoryScanDetails");
        });

        modelBuilder.Entity<InventoryScanDetail>(entity =>
        {
            entity.HasOne(d => d.FirstScanUserNavigation).WithMany(p => p.InventoryScanDetailFirstScanUserNavigations).HasConstraintName("FK_InventoryScanDetails_Users");

            entity.HasOne(d => d.bin).WithMany(p => p.InventoryScanDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryScanDetails_BinLocationReferences");

            entity.HasOne(d => d.controlScanUserNavigation).WithMany(p => p.InventoryScanDetailcontrolScanUserNavigations).HasConstraintName("FK_InventoryScanDetails_CUsers");

            entity.HasOne(d => d.inventoryNavigation).WithMany(p => p.InventoryScanDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryScanDetails_Inventory");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.language).IsFixedLength();
            entity.Property(e => e.processKey).IsFixedLength();

            entity.HasOne(d => d.clientNavigation).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Orders_Clients");

            entity.HasOne(d => d.rootOrderNavigation).WithMany(p => p.InverserootOrderNavigation).HasConstraintName("FK_Orders_Orders");

            entity.HasOne(d => d.thirdScanUserNavigation).WithMany(p => p.OrderthirdScanUserNavigations).HasConstraintName("fk_Orders_Users1");

            entity.HasOne(d => d.userNavigation).WithMany(p => p.OrderuserNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Orders_Users");
        });

        modelBuilder.Entity<OrderPicklist>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_OrderPackLists");
        });

        modelBuilder.Entity<OrderPicklistBinLocationReservation>(entity =>
        {
            entity.HasOne(d => d.articleNavigation).WithMany(p => p.OrderPicklistBinLocationReservations).HasConstraintName("fk_OrderPicklistBinLocationReservations_Articles");

            entity.HasOne(d => d.articleSwapNavigation).WithMany(p => p.OrderPicklistBinLocationReservations).HasConstraintName("FK_OrderPicklistBinLocationReservations_ArticleSwap");

            entity.HasOne(d => d.binLocationNavigation).WithMany(p => p.OrderPicklistBinLocationReservations).HasConstraintName("FK_OrderPicklistBinLocationReservations_BinLocationReferences");

            entity.HasOne(d => d.orderPositionNavigation).WithMany(p => p.OrderPicklistBinLocationReservations).HasConstraintName("FK_OrderPicklistBinLocationReservations_OrderPositions");

            entity.HasOne(d => d.orderReturnNavigation).WithMany(p => p.OrderPicklistBinLocationReservations).HasConstraintName("FK_OrderPicklistBinLocationReservations_OrderReturns");
        });

        modelBuilder.Entity<OrderPosition>(entity =>
        {
            entity.HasOne(d => d.articleNavigation).WithMany(p => p.OrderPositions).HasConstraintName("FK_OrderPositions_Articles");

            entity.HasOne(d => d.colorNavigation).WithMany(p => p.OrderPositions).HasConstraintName("FK_OrderPositions_ClientColorCodes");

            entity.HasOne(d => d.firstScanUserNavigation).WithMany(p => p.OrderPositionfirstScanUserNavigations).HasConstraintName("FK_OrderPositions_Users");

            entity.HasOne(d => d.orderNavigation).WithMany(p => p.OrderPositions).HasConstraintName("FK_OrderPositions_Orders");

            entity.HasOne(d => d.picklistNavigation).WithMany(p => p.OrderPositions).HasConstraintName("FK_OrderPositions_OrderPackLists");

            entity.HasOne(d => d.secondScanUserNavigation).WithMany(p => p.OrderPositionsecondScanUserNavigations).HasConstraintName("FK_OrderPositions_SecondUsers");

            entity.HasOne(d => d.sizeNavigation).WithMany(p => p.OrderPositions).HasConstraintName("FK_OrderPositions_ClientSizes");
        });

        modelBuilder.Entity<OrderRawDatum>(entity =>
        {
            entity.HasOne(d => d.article).WithMany(p => p.OrderRawData).HasConstraintName("FK_OrderRawData_Articles");

            entity.HasOne(d => d.order).WithMany(p => p.OrderRawData)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_OrderRawData_Orders");

            entity.HasOne(d => d.partnerStore).WithMany(p => p.OrderRawData)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderRawData_PartnerStores");
        });

        modelBuilder.Entity<OrderReturn>(entity =>
        {
            entity.HasOne(d => d.articleNavigation).WithMany(p => p.OrderReturnarticleNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderReturns_Articles");

            entity.HasOne(d => d.changedArticleNavigation).WithMany(p => p.OrderReturnchangedArticleNavigations).HasConstraintName("changedArticle_Articles");

            entity.HasOne(d => d.colorNavigation).WithMany(p => p.OrderReturns).HasConstraintName("FK_OrderReturns_ClientColorCodes");

            entity.HasOne(d => d.firstScanUserNavigation).WithMany(p => p.OrderReturnfirstScanUserNavigations).HasConstraintName("FK_OrderReturns_Users1");

            entity.HasOne(d => d.orderNavigation).WithMany(p => p.OrderReturns).HasConstraintName("FK_OrderReturns_Orders");

            entity.HasOne(d => d.picklistNavigation).WithMany(p => p.OrderReturns).HasConstraintName("FK_OrderReturns_OrderPackLists");

            entity.HasOne(d => d.referencePositionNavigation).WithMany(p => p.OrderReturns)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderReturns_OrderPositions");

            entity.HasOne(d => d.returnedArticleNavigation).WithMany(p => p.OrderReturnreturnedArticleNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("returnedArticle_Articles");

            entity.HasOne(d => d.sizeNavigation).WithMany(p => p.OrderReturns).HasConstraintName("FK_OrderReturns_ClientSizes");

            entity.HasOne(d => d.userNavigation).WithMany(p => p.OrderReturnuserNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderReturns_Users");

            entity.HasOne(d => d.wronglyShippedArticle).WithMany(p => p.OrderReturnwronglyShippedArticles)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_OrderReturns_Articles1");
        });

        modelBuilder.Entity<OrderStatusChange>(entity =>
        {
            entity.HasOne(d => d.userNavigation).WithMany(p => p.OrderStatusChanges).HasConstraintName("FK__OrderStatu__user__1B2CFC12");
        });

        modelBuilder.Entity<PartnerStore>(entity =>
        {
            entity.HasOne(d => d.clientNavigation).WithMany(p => p.PartnerStores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PartnerStores_Clients");
        });

        modelBuilder.Entity<Preference>(entity =>
        {
            entity.HasOne(d => d.clientNavigation).WithMany(p => p.Preferences)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Preferences_Clients");
        });

        modelBuilder.Entity<ProcessCost>(entity =>
        {
            entity.Property(e => e.area).IsFixedLength();
            entity.Property(e => e.packlist).IsFixedLength();
        });

        modelBuilder.Entity<ScheduledShippingNotificationDeployment>(entity =>
        {
            entity.HasOne(d => d.userNavigation).WithMany(p => p.ScheduledShippingNotificationDeployments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ScheduledShippingNotificationDeployments_Users");
        });

        modelBuilder.Entity<StoreBinlocationBox>(entity =>
        {
            entity.HasOne(d => d.binLocation).WithMany(p => p.StoreBinlocationBoxes).HasConstraintName("FK_StoreBinlocationBoxes_BinLocationReferences");

            entity.HasOne(d => d.order).WithMany(p => p.StoreBinlocationBoxes).HasConstraintName("FK_StoreBinlocationBoxes_Orders");

            entity.HasOne(d => d.partnerStore).WithMany(p => p.StoreBinlocationBoxes).HasConstraintName("FK_StoreBinlocationBoxes_PartnerStores");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasOne(d => d.lastWarehouseNavigation).WithMany(p => p.UserlastWarehouseNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Warehouses");

            entity.HasOne(d => d.warehouseNavigation).WithMany(p => p.UserwarehouseNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Warehouses1");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasOne(d => d.branchNavigation).WithMany(p => p.Warehouses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouses_Branches");

            entity.HasOne(d => d.clientNavigation).WithMany(p => p.Warehouses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouses_Clients");

            entity.HasOne(d => d.userNavigation).WithMany(p => p.Warehouses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouses_Users");
        });

        modelBuilder.Entity<WarehouseActionLog>(entity =>
        {
            entity.HasOne(d => d.articleNavigation).WithMany(p => p.WarehouseActionLogs).HasConstraintName("FK_WarehouseActionLog_Articles");

            entity.HasOne(d => d.binLocationNavigation).WithMany(p => p.WarehouseActionLogs).HasConstraintName("fk_WarehouseActionLog_BinLocationReferences");

            entity.HasOne(d => d.deliveryReceiptNavigation).WithMany(p => p.WarehouseActionLogs).HasConstraintName("FK__Warehouse__deliv__13C0E474");

            entity.HasOne(d => d.lotNavigation).WithMany(p => p.WarehouseActionLogs).HasConstraintName("fk_WarehouseActionLog_WarehouseActionLogLots");

            entity.HasOne(d => d.userNavigation).WithMany(p => p.WarehouseActionLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_WarehouseActionLog_Users");

            entity.HasOne(d => d.wagonNavigation).WithMany(p => p.WarehouseActionLogs).HasConstraintName("fk_WarehouseActionLog_WarehouseActionLogWagon");

            entity.HasOne(d => d.warehouseNavigation).WithMany(p => p.WarehouseActionLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_WarehouseActionLog_Warehouses");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
