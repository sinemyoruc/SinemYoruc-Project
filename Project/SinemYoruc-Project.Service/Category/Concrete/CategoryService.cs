using AutoMapper;
using NHibernate;
using SinemYoruc_Project.Data;
using SinemYoruc_Project.Dto;

namespace SinemYoruc_Project.Service
{
    public class CategoryService : BaseService<CategoryDto, Category>, ICategoryService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Category> hibernateRepository;

        public CategoryService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Category>(session);
        }


      
    }
}
