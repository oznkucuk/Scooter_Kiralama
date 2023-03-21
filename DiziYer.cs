namespace ScooterKiralama
{

    class DiziYer
    {
        protected static string[] KullanciGiris = { "1A", "1B", "1C", "1D", "1E",
                                                    "2A", "2B", "2C", "2D", "2E",
                                                    "3A", "3B", "3C", "3D", "3E",
                                                    "4A", "4B", "4C", "4D", "4E",
                                                    "5A", "5B", "5C", "5D", "5E" };

        public static int ArkaPlanCevrim(string s)
        {
            for (int i = 0; i < KullanciGiris.Length; i++)
            {
                if (KullanciGiris[i] == s.ToUpper())
                    return i;
            }
            return 0;
        }

    }



}