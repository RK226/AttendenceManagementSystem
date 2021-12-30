using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.BusinessInterface
{
    public interface IYearMasterServices 
    {
        IEnumerable<YearMasterEntity> GetAllYears();
        YearMasterEntity CreateYears(YearMasterEntity yearMasterEntity);
        bool UpdateYears(YearMasterEntity yearMasterEntity);
    }
}
