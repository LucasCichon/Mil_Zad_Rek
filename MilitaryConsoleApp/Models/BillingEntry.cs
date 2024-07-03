
namespace MilitaryConsoleApp.Models
{
    public class BillingEntry
    {
        public string BillingId { get; private set; }
        public string OrderId { get; private set; }
        public string OfferId { get; private set; }
        public string TypeId { get; private set; }
        public string TypeName { get; private set; }
        public DateTime OccuredAt { get; private set; }
        public string TaxPercentage { get; private set; }
        public string TaxAnnotation { get; private set; }
        public decimal BalanceAmount { get; private set; }
        public string BalanceCurrency { get; private set; }

        private BillingEntry(
            string billingId,
            string orderId,
            string offerId,
            string typeId,
            string typeName,
            DateTime occuredAt,
            string taxPercentage,
            string taxAnnotation,
            decimal balanceAmount,
            string balanceCurrency)
        {
            BillingId = billingId;
            OrderId = orderId;
            OfferId = offerId;
            TypeId = typeId;
            TypeName = typeName;
            OccuredAt = occuredAt;
            TaxPercentage = taxPercentage;
            TaxAnnotation = taxAnnotation;
            BalanceAmount = balanceAmount;
            BalanceCurrency = balanceCurrency;
        }

        public class Builder
        {
            private string _billingId;
            private string _orderId;
            private string _offerId;
            private string _typeId;
            private string _typeName;
            private DateTime _occuredAt;
            private string _taxPercentage;
            private string _taxAnnotation;
            private decimal _balanceAmount;
            private string _balanceCurrency;

            public Builder WithBillingId(string billingId)
            {
                _billingId = billingId;
                return this;
            }

            public Builder WithOrderId(string orderId)
            {
                _orderId = orderId;
                return this;
            }

            public Builder WithOfferId(string offerId)
            {
                _offerId = offerId;
                return this;
            }

            public Builder WithTypeId(string typeId)
            {
                _typeId = typeId;
                return this;
            }

            public Builder WithTypeName(string typeName)
            {
                _typeName = typeName;
                return this;
            }

            public Builder WithOccuredAt(DateTime occuredAt)
            {
                _occuredAt = occuredAt;
                return this;
            }

            public Builder WithTaxPercentage(string taxPercentage)
            {
                _taxPercentage = taxPercentage;
                return this;
            }

            public Builder WithTaxAnnotation(string taxAnnotation)
            {
                _taxAnnotation = taxAnnotation;
                return this;
            }

            public Builder WithBalanceAmount(decimal balanceAmount)
            {
                _balanceAmount = balanceAmount;
                return this;
            }

            public Builder WithBalanceCurrency(string balanceCurrency)
            {
                _balanceCurrency = balanceCurrency;
                return this;
            }

            public BillingEntry Build()
            {
                return new BillingEntry(
                    _billingId,
                    _orderId,
                    _offerId,
                    _typeId,
                    _typeName,
                    _occuredAt,
                    _taxPercentage,
                    _taxAnnotation,
                    _balanceAmount,
                    _balanceCurrency);
            }
        }
    }
}
