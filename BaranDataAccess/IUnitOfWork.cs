using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaranDataAccess
{
    public interface IUnitOfWork : System.IDisposable
    {
        bool IsDisposed { get; }

        void Save();
    }
}
