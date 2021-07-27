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
