using BusinessEntities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.BusinessInterface
{
    public interface IDepartmentServices
    {
        IEnumerable<DeparmentMasterEntity> GetAllDepartment();
        DeparmentMasterEntity CreateDepartment(DeparmentMasterEntity deparmentMasterEntity);
        bool UpdateDepartment(DeparmentMasterEntity deparmentMasterEntity);
    }
}
