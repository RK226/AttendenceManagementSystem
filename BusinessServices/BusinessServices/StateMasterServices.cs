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
    public class StateMasterServices : IStateMasterServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AttendenceManagementSystem1Entities _context = new AttendenceManagementSystem1Entities();

        public StateMasterServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public StateMasterEntity CreateState(StateMasterEntity stateMasterEntity)
        {
            var state = new StateMaster
            {


                    StateName = stateMasterEntity.StateName,
                    CountryId = stateMasterEntity.CountryId,
                    CreatedBy = stateMasterEntity.CreatedBy,
                    CreatedDate = DateTime.Now
           
        };
            _unitOfWork.MstStateMasterRepository.Insert(state);
            _unitOfWork.Save();

            return stateMasterEntity;
        }

        public IEnumerable<StateMasterEntity> GetAllState()
        {
            var state = _context.StateMasters.ToList();
            List<StateMasterEntity> lstState = Mapping(state);
            return lstState;
        }

        public bool UpdateState(StateMasterEntity stateMasterEntity)
        {
            var success = false;
            if (stateMasterEntity != null)
            {
                var state = _unitOfWork.MstStateMasterRepository.GetByID(stateMasterEntity.Id);
                if (state != null)
                {


                    state.StateName = stateMasterEntity.StateName;
                    state.CountryId = stateMasterEntity.CountryId;
                    state.ModifyBy = stateMasterEntity.ModifyBy;
                    state.ModifiedDate = DateTime.Now;


                    _unitOfWork.MstStateMasterRepository.Update(state);
                    _unitOfWork.Save();
                }

            }
            return success;
        }

        public List<StateMasterEntity> Mapping(List<StateMaster> deal)
        {
            List<StateMasterEntity> lstMstState = new List<StateMasterEntity>();
            foreach (var item in deal)
            {
                StateMasterEntity objState = new StateMasterEntity();
                objState.Id = item.Id;
                objState.StateName = item.StateName;
                objState.CountryId = item.CountryId;
                objState.CreatedBy = item.CreatedBy;
                objState.CreatedDate = item.CreatedDate;
                objState.ModifyBy = item.ModifyBy;
                objState.ModifiedDate = item.ModifiedDate;

                //CountryMaster countryMaster = item.CountryMaster;
                //if (countryMaster != null)
                //{
                //    CountryMasterEntity countryMasterEntity = new CountryMasterEntity();
                //    countryMasterEntity.Id = countryMaster.Id;
                //    countryMasterEntity.CountryName = countryMaster.CountryName;

                //    objState.CountryMaster = countryMasterEntity;
                //}

                lstMstState.Add(objState);
            }
            return lstMstState;
        }
    }
}
