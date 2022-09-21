using System.Collections.Generic;

namespace SinemYoruc_Project.Data
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual bool isOfferable { get; set; }
        public virtual bool isSold { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Color { get; set; }
        public virtual double Price { get; set; }
        public virtual string Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual ProductsOffer ProductsOffer { get; set; }
        public virtual int AccountId { get; set; }
    }
}
