using DataModel.GenericRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.UnitOfWork
{
   
        public class UnitOfWork : IDisposable, IUnitOfWork
        {
            #region Private member variables...

            private readonly AttendenceManagementSystem1Entities _context = null;

            private GenericRepository<CountryMaster> _mstCountryMasterRepository;
            private GenericRepository<CollegeMaster> _mstCollegeMasterRepository;
            private GenericRepository<StateMaster> _mstStateMasterRepository;
            private GenericRepository<DistrictMaster> _mstDistrictMasterRepository; 
            private GenericRepository<DeparmentMaster> _mstDeparmentMasterRepository; 
            private GenericRepository<BranchMaster> _mstBranchMasterRepository;
            private GenericRepository<SectionMaster> _mstSectionMasterRepository;
            private GenericRepository<StandardMaster> _mstStandardMasterRepository;
            private GenericRepository<Student> _mstStudentRepository;
            private GenericRepository<SubjectMaster> _mstSubjectMasterRepository;
            private GenericRepository<YearMaster> _mstYearMasterRepository;
            private GenericRepository<DivisionMaster> _mstDivisionMasterRepository;


        #endregion

        public UnitOfWork()
            {
                _context = new AttendenceManagementSystem1Entities();
            }

        #region Public Repository Creation properties...

        public GenericRepository<DivisionMaster> MstDivisionMasterRepository
        {
            get
            {
                if (this._mstDivisionMasterRepository == null)
                    this._mstDivisionMasterRepository = new GenericRepository<DivisionMaster>(_context);
                return _mstDivisionMasterRepository;
            }
        }

        public GenericRepository<YearMaster> MstYearMasterRepository
        {
            get
            {
                if (this._mstYearMasterRepository == null)
                    this._mstYearMasterRepository = new GenericRepository<YearMaster>(_context);
                return _mstYearMasterRepository;
            }
        }

        public GenericRepository<SubjectMaster> MstSubjectMasterRepository
        {
            get
            {
                if (this._mstSubjectMasterRepository == null)
                    this._mstSubjectMasterRepository = new GenericRepository<SubjectMaster>(_context);
                return _mstSubjectMasterRepository;
            }
        }

        public GenericRepository<Student> MstStudentRepository
        {
            get
            {
                if (this._mstStudentRepository == null)
                    this._mstStudentRepository = new GenericRepository<Student>(_context);
                return _mstStudentRepository;
            }
        }

        public GenericRepository<StandardMaster> MstStandardMasterRepository
        {
            get
            {
                if (this._mstStandardMasterRepository == null)
                    this._mstStandardMasterRepository = new GenericRepository<StandardMaster>(_context);
                return _mstStandardMasterRepository;
            }
        }

        public GenericRepository<SectionMaster> MstSectionMasterRepository
        {
            get
            {
                if (this._mstSectionMasterRepository == null)
                    this._mstSectionMasterRepository = new GenericRepository<SectionMaster>(_context);
                return _mstSectionMasterRepository;
            }
        }

        public GenericRepository<DistrictMaster> MstDistrictMasterRepository
        {
            get
            {
                if (this._mstDistrictMasterRepository == null)
                    this._mstDistrictMasterRepository = new GenericRepository<DistrictMaster>(_context);
                return _mstDistrictMasterRepository;
            }
        }


        public GenericRepository<StateMaster> MstStateMasterRepository
        {
            get
            {
                if (this._mstStateMasterRepository == null)
                    this._mstStateMasterRepository = new GenericRepository<StateMaster>(_context);
                return _mstStateMasterRepository;
            }
        }

        public GenericRepository<CountryMaster> MstCountryMasterRepository
        {
            get
            {
                if (this._mstCountryMasterRepository == null)
                    this._mstCountryMasterRepository = new GenericRepository<CountryMaster>(_context);
                return _mstCountryMasterRepository;
            }
        }

        public GenericRepository<CollegeMaster> MstCollegeMasterRepository
        {
            get
            {
                if (this._mstCollegeMasterRepository == null)
                    this._mstCollegeMasterRepository = new GenericRepository<CollegeMaster>(_context);
                return _mstCollegeMasterRepository;
            }
        }

        public GenericRepository<DeparmentMaster> MstDeparmentMasterRepository
        {
            get
            {
                if (this._mstDeparmentMasterRepository == null)
                    this._mstDeparmentMasterRepository = new GenericRepository<DeparmentMaster>(_context);
                return _mstDeparmentMasterRepository;
            }
        }

        public GenericRepository<BranchMaster> MstBranchMasterRepository
        {
            get
            {
                if (this._mstBranchMasterRepository == null)
                    this._mstBranchMasterRepository = new GenericRepository<BranchMaster>(_context);
                return _mstBranchMasterRepository;
            }
        }


        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
            {
                try
                {
                    _context.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {

                    var outputLines = new List<string>();
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                        foreach (var ve in eve.ValidationErrors)
                        {
                            outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                        }
                    }
                    System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                    throw e;
                }

            }

            #endregion

            #region Implementing IDiosposable...

            #region private dispose variable declaration...
            private bool disposed = false;
            #endregion

            /// <summary>
            /// Protected Virtual Dispose method
            /// </summary>
            /// <param name="disposing"></param>
            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        Debug.WriteLine("UnitOfWork is being disposed");
                        _context.Dispose();
                    }
                }
                this.disposed = true;
            }

            /// <summary>
            /// Dispose method
            /// </summary>
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            #endregion
        }
    
}
