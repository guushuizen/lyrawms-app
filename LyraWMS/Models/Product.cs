using System.Collections.Generic; 
using System; 
namespace LyraWMS.Models{ 

    public class Product
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public object ParentId { get; set; }
        public object ProductImportId { get; set; }
        public int FulfilmentclientId { get; set; }
        public string Sku { get; set; }
        public string SkuType { get; set; }
        public string Name { get; set; }
        public object InternalDescription { get; set; }
        public object Copy { get; set; }
        public string Barcode { get; set; }
        public int Price { get; set; }
        public int Vat { get; set; }
        public object SupplierId { get; set; }
        public int ProductionCosts { get; set; }
        public int PurchasePrice { get; set; }
        public int SupplierMinimumOrderQuantity { get; set; }
        public int Stock { get; set; }
        public int ReservedStock { get; set; }
        public int KeepStockAsBuffer { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public object Height { get; set; }
        public object Width { get; set; }
        public object Length { get; set; }
        public int Weight { get; set; }
        public object Size { get; set; }
        public bool SizeSetManually { get; set; }
        public string CountryOfOrigin { get; set; }
        public object HsCode { get; set; }
        public object FullDescriptionOfGoods { get; set; }
        public int RequiresIdCheck { get; set; }
        public object PackingMethod { get; set; }
        public object TypeOfGoods { get; set; }
        public object GnCode { get; set; }
        public int ShipsAbroad { get; set; }
        public object ProfilePhotoPath { get; set; }
        public bool Active { get; set; }
        public object DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public object LastStockSyncAt { get; set; }
        public int SkipAutomaticAdditionWhenNoStock { get; set; }
        public bool IsSealed { get; set; }
        public object Rating { get; set; }
        public bool IsBox { get; set; }
        public bool ExcludeOnPackingSlip { get; set; }
        public int ExcludeFromBatch { get; set; }
        public string ProfilePhotoUrl { get; set; }
        public string TotalStock { get; set; }
        public int TotalReservedStock { get; set; }
        public string CyclingStock { get; set; }
        public int ReservedCyclingStock { get; set; }
        public Pivot Pivot { get; set; }
        public object ProductSize { get; set; }
        public List<ProductLocation> ProductLocations { get; set; }
    }

}