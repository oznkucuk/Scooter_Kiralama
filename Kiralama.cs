using System;

namespace ScooterKiralama
{
    abstract class Kiralama
    {
        public abstract string KiraKodu { get; }
        public abstract int TabanFiyat { get; }

        public abstract double KiraBedeliSaniye { get; }

        public abstract DateTime TeslimAlmaZamani { get; set; }
        public abstract DateTime TeslimEtmeZamani { get; set; }

        public virtual double KullanimUcreti()
        {
            return 0;
        }
    }
}
