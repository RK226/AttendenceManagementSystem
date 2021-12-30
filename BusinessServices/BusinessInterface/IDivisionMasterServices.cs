using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.BusinessInterface
{
    public interface IDivisionMasterServices
    {
        IEnumerable<DivisionMasterEntity> GetAllDivision();
        DivisionMasterEntity CreateDivision(DivisionMasterEntity divisionMasterEntity);
        bool UpdateDivision(DivisionMasterEntity divisionMasterEntity);
    }
}
