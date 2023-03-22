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
    public class EkipZimmetDAL : IVeriCekID<EkipZimmetDTO>
    {
        List<EkipZimmetDTO> ekipZimmetler;

        public List<EkipZimmetDTO> VeriCek(int id)
        {
            string sorgu = $"select ez.EkipZimmetID as [Kayıt Numarası], v.Barkod, ut.UrunTipi as [Ürün Tipi], fy.ParaMiktari as Fiyat, marka.MarkaAdi as Marka , Model.ModelAd as Model , v.VarlikID from  EkipZimmet ez join Ekip e on ez.EkipID = e.EkipID join Zimmet z on ez.ZimmetID = z.ZimmetID join VarlikDepo vd on z.VarlikDepoID = vd.VarlikDepoID join Varlik v on vd.VarlikID = v.VarlikID join UrunTipi ut on v.UrunTipiID = ut.UrunTipiID join Fiyat fy on fy.VarlikID = v.VarlikID join Model model on v.ModelID = model.ModelID join Marka marka on model.MarkaID = marka.MarkaID where ez.EkipID = {id} and ez.AktifMi = 'True' and fy.AktifMi = 'True'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader dataReader = provider.ExecuteReaderOlustur();
            if (dataReader.HasRows)
            {
                ekipZimmetler = new List<EkipZimmetDTO>();
                while (dataReader.Read())
                {
                    UrunTipiDTO urunTipi = new UrunTipiDTO() { UrunTipiAdi = dataReader.GetString(2) };
                    ModelDTO model = new ModelDTO() { ModelAdi = dataReader.GetString(5), Marka = new MarkaDTO() { MarkaAdi = dataReader.GetString(4) } };
                    VarlikDTO varlik = new VarlikDTO() { VarlikID = dataReader.GetInt32(6),Barkod = Guid.Empty, UrunTipi = urunTipi, Model = model, GuncelFiyat = dataReader.GetDecimal(3) };
                    ZimmetDTO zimmet = new ZimmetDTO() { ZimmetID = dataReader.GetInt32(0), Varlik = varlik };
                    EkipZimmetDTO ekipZimmet = new EkipZimmetDTO() { EkipZimmetID = dataReader.GetInt32(0), Zimmet = zimmet };
                    try
                    {
                        ekipZimmet.Zimmet.Varlik.Barkod = dataReader.GetGuid(1);
                    }
                    catch (Exception ex)
                    {
                    }
                    ekipZimmetler.Add(ekipZimmet);
                }
            }
            return ekipZimmetler;
        }
    }
}
