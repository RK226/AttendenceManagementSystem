using BusinessEntity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.BusinessInterface
{
    public interface IAttendenceServices
    {
        IEnumerable<StudentAttendenceEntity> GetAllAttendence();
        StudentAttendenceEntity CreateAttendence(StudentAttendenceEntity attendenceEntity);
        bool UpdateAttendence(StudentAttendenceEntity attendenceEntity);
    }
}
