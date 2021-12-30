using BusinessEntities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.BusinessInterface
{
    public interface ICollegeMasterServices
    {
        IEnumerable<CollegeMasterEntity> GetAllCollege();
        CollegeMasterEntity CreateCollege(CollegeMasterEntity collegeMasterEntity);
        bool UpdateCollege(CollegeMasterEntity collegeMasterEntity);
    }
}
