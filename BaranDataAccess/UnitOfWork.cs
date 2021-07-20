using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaranDataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
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
            throw new NotImplementedException();
        }
    }
}
