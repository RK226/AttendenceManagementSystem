using BusinessEntity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.BusinessInterface
{
    public interface IStudentServices
    {
        IEnumerable<StudentEntity> GetAllStudent();
        StudentEntity CreateStudent(StudentEntity studentEntity);
        bool UpdateStudent(StudentEntity collegeMasterEntity);
    }
}
