using BusinessEntities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.BusinessInterface
{
    public interface IBranchMasterServices
    {
        IEnumerable<BranchMasterEntity> GetAllBranch();
        BranchMasterEntity CreateBranch(BranchMasterEntity branchMasterEntity);
        bool UpdateBranch(BranchMasterEntity branchMasterEntity);
    }
}
