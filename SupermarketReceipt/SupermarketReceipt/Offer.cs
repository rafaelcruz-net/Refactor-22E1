using System;

namespace SupermarketReceipt
{
    public enum SpecialOfferType
    {
        ThreeForTwo,
        PercentDiscount,
        OfferForAmount,
    }

    public enum SpecialOfferPercentDiscount
    {
        TenPercent = 10,
        TwentyPercent = 20,
        FiftyPercent = 50,
    }

    public enum AmountOfferType
    {
        TwoForAmount = 2,
        FiveForAmount = 5,
        EightForAmount = 8,
        TenForAmount = 10,
    }


    public class Offer
    {
        private Product _product;

        public Offer(SpecialOfferType offerType, Product product, double argument)
        {
            OfferType = offerType;
            Argument = argument;
            _product = product;
        }

        public Offer(SpecialOfferType offerType, Product product, double argument, AmountOfferType amountOfferType = AmountOfferType.TwoForAmount)
        {
            OfferType = offerType;
            Argument = argument;
            AmountOffer = (int)amountOfferType;
            _product = product;
            
        }

        public Offer(Product product, double argument)
        {
            Argument = argument;
            _product = product;
        }


        public SpecialOfferType OfferType { get; } = SpecialOfferType.PercentDiscount;
        public double Argument { get; }

        public int AmountOffer { get; private set; } = (int)AmountOfferType.TwoForAmount;
    }
}