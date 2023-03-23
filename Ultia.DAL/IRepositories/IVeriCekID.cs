using System.Collections.Generic;

namespace Ultia.DAL.IRepositories
{
    public interface IVeriCekID<T> where T : class
    {

        List<T> VeriCek(int id);
    }
}
