using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_02_15.Helper
{
    public static class StringExtend
    {
        public static string inicijalImenaSaPrezimenom(this string imePrezime)
        {
            int pozicija = imePrezime.IndexOf(' ');
            string prezime = imePrezime.Substring(pozicija + 1, imePrezime.Length);
            return imePrezime[0] + "." + prezime + ".";
        }

    }
}
