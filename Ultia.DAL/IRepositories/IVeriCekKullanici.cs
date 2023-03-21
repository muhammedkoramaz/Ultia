using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultia.DTO;
using Ultia.DTO.DTOs;

namespace Ultia.DAL.IRepositories
{
    public interface IVeriCekKullanici<T> where T : class
    {
        KullaniciDTO VeriCek(string kullaniciAdi, string sifre);
    }
}
