using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultia.DTO;

namespace Ultia.DAL.IRepositories
{
    public interface IEkle<T> where T : class
    {
        DonenSonuc Ekle(T eklenecekVeri);
    }
}
