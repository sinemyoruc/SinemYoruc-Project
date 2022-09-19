using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace SinemYoruc_Project.Data
{
    public class ProductDetailMap : ClassMapping<ProductDetail>
    {
        public ProductDetailMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(x => x.ProductId, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });

            Property(b => b.isOfferable, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
            });

            Property(b => b.Offer, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Double);
                x.NotNullable(true);
            });

            Table("productdetail");
        }
    }
}
