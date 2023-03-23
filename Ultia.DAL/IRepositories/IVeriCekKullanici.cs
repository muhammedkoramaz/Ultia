using Ultia.DTO.DTOs;

namespace Ultia.DAL.IRepositories
{
    public interface IVeriCekKullanici<T> where T : class
    {
        KullaniciDTO VeriCek(string kullaniciAdi, string sifre);
    }
}
