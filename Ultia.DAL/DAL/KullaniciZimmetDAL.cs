using AdoSample.Provider;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultia.DAL.IRepositories;
using Ultia.DTO.DTOs;

namespace Ultia.DAL.DAL
{
    public class KullaniciZimmetDAL : IVeriCekID<KullaniciZimmetDTO>
    {
        List<KullaniciZimmetDTO> Zimmetler;

        public List<KullaniciZimmetDTO> VeriCek(int id)
        {
            string sorgu = $"select kz.KullaniciZimmetID as [Kayıt Numarası], v.Barkod, ut.UrunTipi as [Ürün Tipi], fy.ParaMiktari as Fiyat , marka.MarkaAdi as Marka , Model.ModelAd as Model from KullaniciZimmet kz join Kullanici k on kz.KullaniciID = k.KullaniciID join Zimmet z on kz.ZimmetID = z.ZimmetID join VarlikDepo vd on z.VarlikDepoID = vd.VarlikDepoID join Varlik v on vd.VarlikID = v.VarlikID join UrunTipi ut on v.UrunTipiID = ut.UrunTipiID join Fiyat fy on fy.VarlikID = v.VarlikID join Model model on v.ModelID = model.ModelID join Marka marka on model.MarkaID = marka.MarkaID where kz.KullaniciID = {id} and kz.AktifMi= 'True'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader dataReader = provider.ExecuteReaderOlustur();
            if (dataReader.HasRows)
            {
                Zimmetler = new List<KullaniciZimmetDTO>();
                while (dataReader.Read())
                {
                    UrunTipiDTO urunTipi = new UrunTipiDTO() { UrunTipiAdi = dataReader.GetString(2) };
                    ModelDTO model = new ModelDTO() { ModelAdi = dataReader.GetString(5), Marka = new MarkaDTO() {MarkaAdi= dataReader.GetString(4) }  };
                    VarlikDTO varlik = new VarlikDTO() { Barkod = Guid.Empty, UrunTipi = urunTipi, Model = model, GuncelFiyat = dataReader.GetDecimal(3) };
                    ZimmetDTO zimmet = new ZimmetDTO() { ZimmetID = dataReader.GetInt32(0), Varlik = varlik };
                    KullaniciZimmetDTO kullaniciZimmet = new KullaniciZimmetDTO() { KullaniciZimmetID = dataReader.GetInt32(0), Zimmet = zimmet };
                    try
                    {
                        kullaniciZimmet.Zimmet.Varlik.Barkod = dataReader.GetGuid(1);
                    }
                    catch (Exception ex)
                    {
                    }
                    Zimmetler.Add(kullaniciZimmet);
                }
            }
            return Zimmetler;
        }
    }
}