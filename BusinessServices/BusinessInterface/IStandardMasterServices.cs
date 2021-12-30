using BusinessEntity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.BusinessInterface
{
    public interface IStandardMasterServices
    {
        IEnumerable<StandardMasterEntity> GetAllStd();
        StandardMasterEntity CreateStd(StandardMasterEntity standardMasterEntity);
        bool UpdateStd(StandardMasterEntity standardMasterEntity);
    }
}
