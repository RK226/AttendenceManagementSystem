using BusinessEntities;
using BusinessEntity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.BusinessInterface
{
    public interface IUserDetailServices
    {
        IEnumerable<UserDetailsMasterEntity> GetAllUserDetails();
        UserDetailsMasterEntity CreateUserDetails(UserDetailsMasterEntity userDetailsMasterEntity);
        bool UpdateUserDetails(UserDetailsMasterEntity userDetailsMasterEntity);
    }
}
