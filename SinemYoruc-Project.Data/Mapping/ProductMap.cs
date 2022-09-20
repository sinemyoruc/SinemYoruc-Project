using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
namespace SinemYoruc_Project.Data
{
    public class ProductMap : ClassMapping<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.isOfferable, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
            });


            Property(b => b.isSold, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
            });

            Property(b => b.Name, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.Description, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.Color, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.Price, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Double);
                x.NotNullable(true);
            });

            Property(b => b.AccountId, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(false);
            });

            ManyToOne(product => product.ProductsOffer, map => map.Column("OfferId"));

            ManyToOne(product => product.Category, map => map.Column("CategoryId"));

            Table("product");
        }
    }
}
