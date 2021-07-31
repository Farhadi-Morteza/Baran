using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaranDataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        AMSEntities DatabaseContext = new AMSEntities();

        // **************************************************
        //private IXXXXXRepository _xXXXXRepository;

        //public IXXXXXRepository XXXXXRepository
        //{
        //	get
        //	{
        //		if (_xXXXXRepository == null)
        //		{
        //			_xXXXXRepository =
        //				new XXXXXRepository(DatabaseContext);
        //		}

        //		return _xXXXXRepository;
        //	}
        //}
        // **************************************************
        // **************************************************
        private Repository<tbl_src_Part> _partRepository;

        public IRepository<tbl_src_Part> PartRepository
        {
            get
            {
                if (_partRepository == null)
                {
                    _partRepository = new Repository<tbl_src_Part>(DatabaseContext);
                }

                return _partRepository;
            }
        }
        // **************************************************

        // **************************************************
        private Repository<tbl_src_Field> _fieldRepository;

        public IRepository<tbl_src_Field> FieldRepository
        {
            get
            {
                if (_fieldRepository == null)
                {
                    _fieldRepository = new Repository<tbl_src_Field>(DatabaseContext);
                }

                return _fieldRepository;
            }
        }
        // **************************************************
        // **************************************************
        private Repository<tbl_src_Buildings> _buildingsRepository;

        public IRepository<tbl_src_Buildings> BuildingsRepository
        {
            get
            {
                if (_buildingsRepository == null)
                {
                    _buildingsRepository = new Repository<tbl_src_Buildings>(DatabaseContext);
                }

                return _buildingsRepository;
            }
        }
        // **************************************************
        // **************************************************
        private Repository<tbl_src_Warehouse> _warehouseRepository;

        public IRepository<tbl_src_Warehouse> WarehouseRepository
        {
            get
            {
                if (_warehouseRepository == null)
                {
                    _warehouseRepository = new Repository<tbl_src_Warehouse>(DatabaseContext);
                }

                return _warehouseRepository;
            }
        }
        // **************************************************
        // **************************************************
        private Repository<tbl_src_Water> _waterRepository;

        public IRepository<tbl_src_Water> WaterRepository
        {
            get
            {
                if (_waterRepository == null)
                {
                    _waterRepository = new Repository<tbl_src_Water>(DatabaseContext);
                }

                return _waterRepository;
            }
        }
        // **************************************************
        // **************************************************
        private Repository<tbl_src_WaterStorage> _waterStorageRepository;

        public IRepository<tbl_src_WaterStorage> WaterStorageRepository
        {
            get
            {
                if (_waterStorageRepository == null)
                {
                    _waterStorageRepository = new Repository<tbl_src_WaterStorage>(DatabaseContext);
                }

                return _waterStorageRepository;
            }
        }
        // **************************************************
        // **************************************************
        private Repository<tbl_src_WaterTransmissionLine> _waterTransmissionLineRepository;

        public IRepository<tbl_src_WaterTransmissionLine> WaterTransmissionLineRepository
        {
            get
            {
                if (_waterTransmissionLineRepository == null)
                {
                    _waterTransmissionLineRepository = new Repository<tbl_src_WaterTransmissionLine>(DatabaseContext);
                }

                return _waterTransmissionLineRepository;
            }
        }
        // **************************************************

        // **************************************************
        public bool IsDisposed
        {
            get { throw new NotImplementedException(); }
        }

        public void Save()
        {
            DatabaseContext.SaveChanges();
        }

        public void Dispose()
        {
            DatabaseContext.Dispose();
            DatabaseContext = null;
        }
    }
}
