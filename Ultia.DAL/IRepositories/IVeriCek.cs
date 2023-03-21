using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultia.DAL.IRepositories
{
    public interface IVeriCek<T> where T : class
    {
        List<T> VeriCek();
    }
}
