namespace SinemYoruc_Project.Data
{
    public class ProductsOffer
    {
        public virtual int Id { get; set; }
        public virtual int ProductId { get; set; }
        public virtual double Offer { get; set; }
        public virtual int OfferAccountId { get; set; }
        public virtual bool OfferStatus { get; set; }

    }
}
