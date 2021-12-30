using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.BusinessInterface
{
    public interface IStateMasterServices
    {
        IEnumerable<StateMasterEntity> GetAllState();
        StateMasterEntity CreateState(StateMasterEntity stateMasterEntity);
        bool UpdateState(StateMasterEntity stateMasterEntity);
    }
}
