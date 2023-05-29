using System.Text.Json.Serialization;

namespace LyraWMS.Models;

public class Product
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }

    [JsonPropertyName("parent_id")]
    public object ParentId { get; set; }

    [JsonPropertyName("product_import_id")]
    public object ProductImportId { get; set; }

    [JsonPropertyName("fulfilmentclient_id")]
    public int FulfilmentclientId { get; set; }

    [JsonPropertyName("sku")]
    public string Sku { get; set; }

    [JsonPropertyName("sku_type")]
    public string SkuType { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("internal_description")]
    public object InternalDescription { get; set; }

    [JsonPropertyName("copy")]
    public object Copy { get; set; }

    [JsonPropertyName("barcode")]
    public object Barcode { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("vat")]
    public int Vat { get; set; }

    [JsonPropertyName("supplier_id")]
    public object SupplierId { get; set; }

    [JsonPropertyName("production_costs")]
    public int ProductionCosts { get; set; }

    [JsonPropertyName("purchase_price")]
    public int PurchasePrice { get; set; }

    [JsonPropertyName("supplier_minimum_order_quantity")]
    public int SupplierMinimumOrderQuantity { get; set; }

    [JsonPropertyName("stock")]
    public int Stock { get; set; }

    [JsonPropertyName("reserved_stock")]
    public int ReservedStock { get; set; }

    [JsonPropertyName("keep_stock_as_buffer")]
    public int KeepStockAsBuffer { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }

    [JsonPropertyName("length")]
    public int Length { get; set; }

    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    [JsonPropertyName("size")]
    public object Size { get; set; }

    [JsonPropertyName("size_set_manually")]
    public bool SizeSetManually { get; set; }

    [JsonPropertyName("country_of_origin")]
    public string CountryOfOrigin { get; set; }

    [JsonPropertyName("hs_code")]
    public string HsCode { get; set; }

    [JsonPropertyName("full_description_of_goods")]
    public string FullDescriptionOfGoods { get; set; }

    [JsonPropertyName("requires_id_check")]
    public int RequiresIdCheck { get; set; }

    [JsonPropertyName("packing_method")]
    public object PackingMethod { get; set; }

    [JsonPropertyName("type_of_goods")]
    public object TypeOfGoods { get; set; }

    [JsonPropertyName("gn_code")]
    public object GnCode { get; set; }

    [JsonPropertyName("ships_abroad")]
    public int ShipsAbroad { get; set; }

    [JsonPropertyName("profile_photo_path")]
    public object ProfilePhotoPath { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("deleted_at")]
    public object DeletedAt { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("last_stock_sync_at")]
    public object LastStockSyncAt { get; set; }

    [JsonPropertyName("skip_automatic_addition_when_no_stock")]
    public int SkipAutomaticAdditionWhenNoStock { get; set; }

    [JsonPropertyName("is_sealed")]
    public bool IsSealed { get; set; }

    [JsonPropertyName("rating")]
    public object Rating { get; set; }

    [JsonPropertyName("is_box")]
    public bool IsBox { get; set; }

    [JsonPropertyName("exclude_on_packing_slip")]
    public bool ExcludeOnPackingSlip { get; set; }

    [JsonPropertyName("profile_photo_url")]
    public string ProfilePhotoUrl { get; set; }

    [JsonPropertyName("total_stock")]
    public string TotalStock { get; set; }

    [JsonPropertyName("total_reserved_stock")]
    public int TotalReservedStock { get; set; }

    [JsonPropertyName("cycling_stock")]
    public string CyclingStock { get; set; }

    [JsonPropertyName("reserved_cycling_stock")]
    public int ReservedCyclingStock { get; set; }

    [JsonPropertyName("pivot")]
    public Pivot Pivot { get; set; }

    [JsonPropertyName("product_size")]
    public object ProductSize { get; set; }

    [JsonPropertyName("product_locations")]
    public List<ProductLocation> ProductLocations { get; set; }
}