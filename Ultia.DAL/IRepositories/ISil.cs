using Ultia.DTO;

namespace Ultia.DAL.IRepositories
{
    public interface ISil<T> where T : class
    {
        DonenSonuc Sil(int ID);
    }
}
