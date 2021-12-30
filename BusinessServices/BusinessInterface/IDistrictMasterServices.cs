using BusinessEntity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.BusinessInterface
{
    public interface IDistrictMasterServices
    {
        IEnumerable<DistrictMasterEntity> GetAllDistricts();
        DistrictMasterEntity CreateDistricts(DistrictMasterEntity districtMasterEntity);
        bool UpdateDistricts(DistrictMasterEntity districtMasterEntity);
    }
}
