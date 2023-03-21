using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultia.DAL.IRepositories
{
    internal interface ITekVeriCek<T> where T : class
    {
        T TekVeriCek(int id);
    }
}
