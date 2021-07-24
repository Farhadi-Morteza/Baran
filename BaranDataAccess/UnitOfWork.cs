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
        //private IFieldRepository _fieldRepository;

        //public IFieldRepository FieldRepository
        //{
        //    get
        //    {
        //        if (_fieldRepository == null)
        //        {
        //            _fieldRepository = new FieldRepository(DatabaseContext);
        //        }

        //        return _fieldRepository;
        //    }
        //}
        // **************************************************
        public bool IsDisposed
        {
            get { throw new NotImplementedException(); }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            DatabaseContext.Dispose();
            DatabaseContext = null;
        }
    }
}
