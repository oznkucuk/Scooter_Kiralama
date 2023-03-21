using System;

namespace ScooterKiralama
{
    class Program
    {
        static void Main(string[] args)
        {
            Harita m = new Harita();
            bool devam = true;
            while (devam)
            {
                Console.WriteLine("Yapacağınız işlemi seçiniz");
                Console.WriteLine("(1)-Scooter Teslim Alma \n(2)-Scooter Teslim Etme \n(3)Çıkış");
                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        Harita.HaritaGöster();
                        if (Harita.BolgedenScooterTeslimAlma())
                            Console.WriteLine("Kiralama İşlemi Başarılı");
                        Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*");
                        break;
                    case "2":
                        if (Islem.KiralamaKoduDoğrulama())
                        {
                            Console.WriteLine("Teslim Etme İşlemi Başarılı");
                            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*");
                        }
                        else
                            Console.WriteLine("Hatalı Kod Girdiniz!!!");
                        break;
                    case "3":
                        devam = false;
                        break;
                    default:
                        Console.WriteLine("Hatalı seçim!!!"); break;
                }









            }
        }
    }
}