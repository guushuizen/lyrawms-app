using System; 
namespace LyraWMS.Models{ 

    public class Order
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public object ParentId { get; set; }
        public string FulfilmentClientId { get; set; }
        public int CustomerId { get; set; }
        public int ShippingAddressId { get; set; }
        public int BillingAddressId { get; set; }
        public string Reference { get; set; }
        public object SalesChannelId { get; set; }
        public string SaleschannelForeignOrderId { get; set; }
        public string SaleschannelForeignOrderReference { get; set; }
        public object SaleschannelForeignOrderRequiredCourierType { get; set; }
        public object SaleschannelForeignOrderAdditionalData { get; set; }
        public bool IsGift { get; set; }
        public bool SundayDelivery { get; set; }
        public bool EveningDelivery { get; set; }
        public bool PrefersSameDayDelivery { get; set; }
        public object CourierId { get; set; }
        public object ShippingMethodId { get; set; }
        public int AcceptsReturns { get; set; }
        public bool IsB2bOrder { get; set; }
        public object Transporters { get; set; }
        public object SenderInstructions { get; set; }
        public object SpecialAgreements { get; set; }
        public int Franco { get; set; }
        public object RepaymentAgreement { get; set; }
        public object CmrAttatchedDocuments { get; set; }
        public int IsUrgent { get; set; }
        public string Status { get; set; }
        public string OrderedAt { get; set; }
        public object SnoozedUntil { get; set; }
        public object SnoozeReason { get; set; }
        public object PausedAt { get; set; }
        public object PausedReason { get; set; }
        public object ExpectedShippingDate { get; set; }
        public object ShippedAt { get; set; }
        public object EditingStartedAt { get; set; }
        public object DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int IsVvbOrder { get; set; }
        public object VvbTransporterCode { get; set; }
        public object ReturnOrderId { get; set; }
        public object ExtraFields { get; set; }
        public string Lang { get; set; }
        public object DeletionReason { get; set; }
        public bool IsConcept { get; set; }
        public Customer Customer { get; set; }
        public FulfilmentClient? FulfilmentClient { get; set; }
        public object SalesChannel { get; set; }
    }

}