using System.Collections.Generic;

namespace Ultia.DAL.IRepositories
{
    public interface IVeriCek<T> where T : class
    {
        List<T> VeriCek();
    }
}
