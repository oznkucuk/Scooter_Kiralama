using System;

namespace ScooterKiralama
{

    class Harita
    {
        public static int[] yerler = new int[25];
        public Harita()
        {
            ScooterDagitim();
        }

        public static void HaritaGöster()
        {
            Console.WriteLine();
            Console.WriteLine(" --A-+-B-+-C-+-D-+-E-");
            for (int i = 0; i < 25; i++)
            {
                if (i == 0)
                    Console.Write("1");
                if (i == 5)
                    Console.Write("2");
                if (i == 10)
                    Console.Write("3");
                if (i == 15)
                    Console.Write("4");
                if (i == 20)
                    Console.Write("5");
                if (yerler[i] == 0)
                    Console.Write($"|   ");
                else
                    Console.Write($"| {yerler[i]} ");
                if ((i + 1) % 5 == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine(" +---+---+---+---+---");
                }
            }
        }
        private static void ScooterDagitim()
        {
            Random m = new Random();
            for (int i = 0; i < 15; i++)
            {
                int sayi = m.Next(25);
                if (yerler[sayi] < 2)
                    yerler[sayi]++;
            }
        }
        public static bool İndexDolumu(int index)
        {
            if (yerler[index] > 0)
                return true;
            else
                return false;

        }
        public static void TeslimEtmeYeri()
        {
            HaritaGöster();
            Console.WriteLine("--------------------------");
            Console.WriteLine("Scooter'ı Teslim Etmek İstediğiniz Bölgeyi Seçin: ");
            Console.WriteLine("--------------------------");
            string teslimYeri = Console.ReadLine();
            int teslimyeridegeri = DiziYer.ArkaPlanCevrim(teslimYeri);
            yerler[teslimyeridegeri]++;
        }
        // public static bool HaritadaScooterVarMi()
        // {
        //     foreach (var item in yerler)
        //     {
        //         if (item < 0)
        //         {
        //             return true;
        //         }
        //     }
        //     return false;
        // }
        public static bool BolgedenScooterTeslimAlma()
        {
            Console.WriteLine("Hangi Bölgeden Scooter Almak İstiyorsunuz");
            string cevap = Console.ReadLine();

            int index = DiziYer.ArkaPlanCevrim(cevap);
            if (Harita.İndexDolumu(index))
            {
                Islem.TeslimAlma(index);
                return true;
            }
            else
                Console.WriteLine("Bu Bölgede Scooter Yoktur!!!");
            return false;
        }

    }
}
