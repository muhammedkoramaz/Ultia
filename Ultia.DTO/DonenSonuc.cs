using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultia.DTO
{
    public class DonenSonuc
    {
        public string DonusMesaji { get; set; }
        public bool DonusTipi { get; set; }
        public object Sonuc { get; set; }
    }
}