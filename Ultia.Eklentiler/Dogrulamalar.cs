using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ultia.Eklentiler
{
    public static class Eklentiler
    {
        /// <summary>
        /// Bu extention method Combobox nesnesinin seçili ögesini kontrol eder ve eğer boş ise false döner.
        /// </summary>
        /// <param name="comboBox"></param>
        /// <returns></returns>
        public static bool IsNotEmptyComboBox(this ComboBox comboBox)
        {
            return comboBox.SelectedItem != null;

        }


        /// <summary>
        /// NumericUpDown boş veya sıfır olamaz.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsZeroOrEmptyNumericUpDown(this int number)
        {
            if (string.IsNullOrWhiteSpace(number.ToString()) && number == 0)
                return false;
            return true;
        }/// <summary>
         /// Ad soyad bilgilerini alan bir alanda kontrol yapan fonksiyon.
         /// Eğer boş ise ya da ad soyad arasında boşluk yok ise false döner.
         /// </summary>
         /// <param name="fullName"></param>
         /// <returns></returns>
        public static bool IsValidFullName(this string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName) && fullName.All(char.IsDigit))
                return false;

            string[] parts = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2)
                return false;

            return true;
        }
        /// <summary>
        /// Telefon numarası alanlarının validasyonları için kullanılacak fonksiyon.
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static bool IsValidPhoneNumber(this string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber) || !phoneNumber.All(char.IsDigit))
            {
                return false;
            }

            // Remove any whitespace, dashes or parentheses from the phone number string
            phoneNumber = Regex.Replace(phoneNumber, @"[\s\-\(\)]", "");

            // Check if the phone number is in the correct format (starts with "0" and has 11 digits)
            return Regex.IsMatch(phoneNumber, @"^0\d{10}$");
            ;
        }
        /// <summary>
        /// Email alanlarının validasyonları için kullanılacak fonksiyon.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// TC Kimlik alanlarının validasyonları için kullanılacak fonksiyon.
        /// TC Kimlik numarası 11 haneli ve sadece rakamlardan oluşmalıdır. 
        /// </summary>
        /// <param name="tckn"></param>
        /// <returns></returns>
        public static bool IsValidTCKN(this string tckn)
        {
            if (string.IsNullOrEmpty(tckn) || tckn.Length != 11 || !tckn.All(char.IsDigit))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// İki tarih arasındaki farkı kontrol eder. 
        /// Başlangıç tarihi bitişten büyük olamaz.
        /// </summary>
        /// <param name="startDate">Karşılaştırılacak başlangıç tarihi.</param>
        /// <param name="endDate">Karşılaştırılacak bitiş tarihi.</param>
        /// <returns></returns>
        public static bool ValidateDateRange(this DateTime startDate, DateTime endDate)
        {
            // Giriş tarihi, çıkış tarihinden önce olmalıdır.
            if (startDate >= endDate)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberText">Kontrolü istenilen string parametre.</param>
        /// <returns></returns>
        public static bool IsNumeric(this string numberText)
        {
            double number;
            return double.TryParse(numberText, out number);
        }
    }
}
