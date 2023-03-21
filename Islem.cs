using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ScooterKiralama
{
    class Islem
    {

        public static void TeslimAlma(int sctkonumdeger)
        {
            Scooter sct = new Scooter();
            sct.TeslimAlmaZamani = DateTime.Now;
            string eklenecekKayit = $"{sct.KiraKodu};{sct.TeslimAlmaZamani};\n";//dosyaya kaydedilecek içeriğin oluşturulması
            File.AppendAllText("KiralamaIslemKayit.csv", eklenecekKayit);//dosyaya içeriğin eklenmesi
            Console.WriteLine("Kiralama İşleminiz İçin Oluşturulan Kodunuz :" + sct.KiraKodu);
            Harita.yerler[sctkonumdeger]--;
        }
        public static void TeslimEtme(string[] dizi)
        {
            Harita.TeslimEtmeYeri();
            string[] satirlar = File.ReadAllLines("KiralamaIslemKayit.csv");
            Scooter s = new Scooter();
            s.TeslimAlmaZamani = DateTime.Parse(dizi[1]);
            s.TeslimEtmeZamani = DateTime.Now;
            Console.WriteLine($"Teslim alınan saat : {s.TeslimAlmaZamani}");
            Console.WriteLine($"Teslim edilen saat : {s.TeslimEtmeZamani}");
            Console.WriteLine("             UCRET : " + Math.Round(s.KullanimUcreti(), 2) + " TL");
            Thread.Sleep(2000);

        }
        public static bool KiralamaKoduDoğrulama()
        {
            Console.Write("Kiralama Kodunu Giriniz: ");
            string kod = Console.ReadLine().ToUpper();
            List<string> diziSatir = new List<string>();
            string[] satirlar = File.ReadAllLines("KiralamaIslemKayit.csv");
            foreach (var item in satirlar)
            {
                diziSatir.Add(item);
            }
            for (int i = 0; i < diziSatir.Count; i++)
            {
                string[] satir = diziSatir[i].Split(';');

                if (satir[0] == kod)
                {
                    Islem.TeslimEtme(satir);
                    diziSatir.RemoveAt(i);
                    KiralamaKoduSilme(diziSatir);
                    return true;

                }
            }
            return false;

        }
        private static void KiralamaKoduSilme(List<string> satirlar)
        {
            File.Delete("KiralamaIslemKayit.csv");
            foreach (var item in satirlar)
            {
                string[] satir = item.Split(';');

                string eklenecekKayit = $"{satir[0]};{satir[1]};\n";
                File.AppendAllText("KiralamaIslemKayit.csv", eklenecekKayit);

            }

        }
    }


}


