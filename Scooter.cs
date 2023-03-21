using System;

namespace ScooterKiralama
{
    class Scooter : Kiralama
    {
        public Scooter()
        {
            kiralamakodusayac++;
        }
        private static int kiralamakodusayac = 9;
        public override double KiraBedeliSaniye { get { return 3; } }
        public override DateTime TeslimAlmaZamani { get; set; }
        public override DateTime TeslimEtmeZamani { get; set; }
        public override string KiraKodu
        {
            get
            {   //kiralanan her scooter'a bir kod üretmek için sayaç kullanıp, string tipine çevirerek toplatıp her seferinde bir kod 
                //üretilip kayıt altına alınmasını sağlıyoruz.
                string soniki = kiralamakodusayac.ToString();
                string ilkdort = "SCTR";
                return ilkdort + soniki;
            }
        }

        public override int TabanFiyat { get { return 5; } }


        public override double KullanimUcreti()
        {
            TimeSpan fark = TeslimEtmeZamani - TeslimAlmaZamani;
            double ucret = (fark.Seconds * KiraBedeliSaniye) + TabanFiyat;
            return ucret;
        }

    }
}
