using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultia.DTO;

namespace Ultia.DAL.IRepositories
{
    public interface IGuncelle<T> where T : class
    {
        DonenSonuc Guncelle(T guncellenecekVeri);
    }
}
