using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.BusinessInterface
{
    public interface ISubjectServices
    {
        IEnumerable<SubjectMasterEntity> GetAllSubjects();
        SubjectMasterEntity CreateSubjects(SubjectMasterEntity subjectMasterEntity);
        bool UpdateSubjects(SubjectMasterEntity subjectMasterEntity);
    }
}
