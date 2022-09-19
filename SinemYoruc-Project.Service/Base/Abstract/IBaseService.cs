using SinemYoruc_Project.Base;
using System.Collections.Generic;

namespace SinemYoruc_Project.Service
{
    public interface IBaseService<Dto, Entity>
    {
        BaseResponse<Dto> GetById(int id);
        BaseResponse<IEnumerable<Dto>> GetAll();
        BaseResponse<Dto> Insert(Dto insertResource);
        BaseResponse<Dto> Update(int id, Dto updateResource);
        BaseResponse<Dto> Remove(int id);
    }
}
