using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace ecom.minhhai.bookstore.Infrastructure
{
    public static class Extension
    {
        public static string ToDolar(this float price)
        {
            return $"${price.ToString("0.00")}";
        }

        public static string RemoveAccents(string input)
        {
            string normalizedString = input.Normalize(NormalizationForm.FormKD);
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string result = regex.Replace(normalizedString, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
            return result;
        }

        public static string SeoURL(string input)
        {
            string encodedUrl = (input ?? "").ToLower();
            encodedUrl = Regex.Replace(encodedUrl, @"\s", "-");
            encodedUrl = RemoveAccents(encodedUrl);
            encodedUrl = Regex.Replace(encodedUrl, @"[^\p{L}0-9\s-]", "");
            encodedUrl = Regex.Replace(encodedUrl, @"-+", "-");
            encodedUrl = encodedUrl.Trim('-');

            return encodedUrl;
        }
        public static string GetRandomKey(int length = 5)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] key = new char[length];

            for (int i = 0; i < length; i++)
            {
                key[i] = chars[random.Next(chars.Length)];
            }

            return new string(key);
        }

        public static bool CheckEmail(string email)
        {
            try
            {
                MailAddress address = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
