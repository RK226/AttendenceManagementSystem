using BusinessEntities;
using BusinessEntity;
using BusinessServices.BusinessInterface;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
namespace BusinessServices.BusinessServices
{
    public class AttendenceServices : IAttendenceServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();

        public AttendenceServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public StudentAttendenceEntity CreateAttendence(StudentAttendenceEntity attendenceEntity)
        {
            var studentAttendence = new StudentAttendence
            {

                CollegeID = attendenceEntity.CollegeID,
                StudentID = attendenceEntity.StudentID,
                SubjectId = attendenceEntity.SubjectId,
                StandardID = attendenceEntity.StandardID,
                DivisionID = attendenceEntity.DivisionID,
                Flag = attendenceEntity.Flag,
                Status = attendenceEntity.Status,
                Remark = attendenceEntity.Remark,
                EntryBy = attendenceEntity.EntryBy,
                EntryDate = DateTime.Now
            };
            _unitOfWork.MstStudentAttendenceRepository.Insert(studentAttendence);
            _unitOfWork.Save();

            return attendenceEntity;
        }

        public IEnumerable<StudentAttendenceEntity> GetAllAttendence()
        {
            throw new NotImplementedException();
        }

        public bool UpdateAttendence(StudentAttendenceEntity attendenceEntity)
        {
            throw new NotImplementedException();
        }
    }
}
