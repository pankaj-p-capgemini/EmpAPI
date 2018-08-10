using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IServices<DTOEntity> where DTOEntity : class
    {
        //IQueryable<DTOEntity> FindBy(Expression<Func<DTOEntity, bool>> predicate);
        IEnumerable<DTOEntity> GetAll();
        DTOEntity FindByID(int pkid);
        DTOEntity Create(DTOEntity entity);
        bool Update(int pkid, DTOEntity entity);
        bool Delete(int pkid);
    }
}
