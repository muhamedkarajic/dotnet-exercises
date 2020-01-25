namespace RS1_Ispit_asp.net_core.Helper
{
    public static class StringExtension
    {
        public static string VratiInicijale(this string imePrezime)
        {
            int found = imePrezime.IndexOf(" ") + 1;
            string prezime = imePrezime.Substring(found);
            return imePrezime[0].ToString() + ". " + prezime[0].ToString() + ".";
        }

        public static string VratiInicijalImena(this string imePrezime)
        {
            int found = imePrezime.IndexOf(" ") + 1;
            string prezime = imePrezime.Substring(found);
            return imePrezime[0].ToString() + ". " + prezime;
        }
    }
}
