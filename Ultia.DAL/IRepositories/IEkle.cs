using Ultia.DTO;

namespace Ultia.DAL.IRepositories
{
    public interface IEkle<T> where T : class
    {
        DonenSonuc Ekle(T eklenecekVeri);
    }
}
