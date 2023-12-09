namespace TYBLOgrenci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Liste ogrenciler = new Liste();
            int numara;
            string ad, soyad, dersadi;
            float vize, final;

            int secim = menu();
            while (secim != 0)
            {
                switch (secim)
                {
                    case 1:
                        {
                            Console.Write("Numara    :"); numara = int.Parse(Console.ReadLine());
                            Console.Write("Ad        :"); ad = Console.ReadLine();
                            Console.Write("Soyad     :"); soyad = Console.ReadLine();
                            Console.Write("Ders Adı  :"); dersadi = Console.ReadLine();
                            Console.Write("Vize      :"); vize = float.Parse(Console.ReadLine());
                            Console.Write("Final     :"); final = float.Parse(Console.ReadLine());
                            ogrenciler.ekle(numara, ad, soyad, dersadi, vize, final);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Numara : "); numara = int.Parse(Console.ReadLine());
                            ogrenciler.sil(numara);
                            break;
                        }
                    case 3:
                        {
                            ogrenciler.yazdir();
                            break;
                        }
                    case 4:
                        {
                            ogrenciler.enBasarili();
                            break;
                        }
                    case 0:
                        break;
                    default:
                        break;
                }
                secim = menu();
            }
        }

        private static int menu()
        {
            int secim;
            Console.WriteLine("1 - Öğrenci Ekle ");
            Console.WriteLine("2 - Öğrenci Sil ");
            Console.WriteLine("3 - Öğrencileri Yazdır ");
            Console.WriteLine("4 - En Yüksek Ortalama ");
            Console.WriteLine("0 - Çıkış");
            Console.Write("Seçiminiz : ");
            secim = int.Parse(Console.ReadLine());
            return secim;
        }
    }
    class Ogrenci
    {
        public int numara;
        public string ad, soyad, dersAdi;
        public float vize, final, ortalama;
        public string durum;
        public Ogrenci next;

        public Ogrenci(int n, string a, string s, string d, float v, float f)
        {
            numara = n; ad = a; soyad = s; dersAdi = d; vize = v; final = f;
            ortalama = vize * 40 / 100 + final * 60 / 100;
            durum = ortalama < 50 ? "Kaldı" : "Geçti";
            next = null;
        }
    }
    class Liste
    {
        Ogrenci head;
        public Liste()
        {
            head = null;
        }
        public void ekle(int n, string a, string s, string d, float v, float f)
        {
            Ogrenci ogr = new Ogrenci(n, a, s, d, v, f);
            if (head == null)
            {
                head = ogr;
                Console.WriteLine(n + " Numaralı Öğrenci Listeye Eklendi ");
            }
            else
            {
                ogr.next = head;
                head = ogr;
                Console.WriteLine(n + " Numaralı Öğrenci Listeye Eklendi ");
            }
        }
        public void sil(int numara)
        {
            bool islemgerceklestimi = false;
            if (head == null)
            {
                islemgerceklestimi = true;
                Console.WriteLine("Listede Öğrenci Yok");
            }
            else if (head.next == null && head.numara == numara)
            {
                head = null;
                islemgerceklestimi = true;
                Console.WriteLine(numara + " Numaralı Öğrenci Listeden Silindi ");
            }
            else if (head.next != null && head.numara == numara)
            {
                head = head.next;
                islemgerceklestimi = true;
                Console.WriteLine(numara + " Numaralı Öğrenci Listeden Silindi ");
            }
            else
            {
                Ogrenci temp = head;
                Ogrenci tempinoncesi = temp;
                while (temp.next != null)
                {
                    if (numara == temp.numara)
                    {
                        tempinoncesi.next = temp.next;
                        islemgerceklestimi = true;
                        Console.WriteLine(numara + " Numaralı Öğrenci Listeden Silindi ");
                    }
                    tempinoncesi = temp;
                    temp = temp.next;
                }
                if (numara == temp.numara)
                {
                    islemgerceklestimi = true;
                    tempinoncesi.next = null;
                    Console.WriteLine(numara + " Numaralı Öğrenci Listeden Silindi ");
                }
            }
            if (islemgerceklestimi == false)
            {
                Console.WriteLine(numara + " Numaralı Öğrenci Bulunamadı !");
            }
        }

        public void yazdir()
        {
            if (head == null)
            {
                Console.WriteLine("Listede Öğrenci Yok !");
            }
            else
            {
                Ogrenci temp = head;
                Console.WriteLine("Numara\t\tAd\t\tSoyad\t\tDers Adı\t\tOrtalama\tDurum\n");
                while (temp.next != null)
                {
                    Console.WriteLine(temp.numara + "\t\t" + temp.ad + "\t\t" + temp.soyad + "\t\t" + temp.dersAdi + "\t\t" + temp.ortalama + "\t\t" + temp.durum);
                    temp = temp.next;
                }
                Console.WriteLine(temp.numara + "\t\t" + temp.ad + "\t\t" + temp.soyad + "\t\t" + temp.dersAdi + "\t\t" + temp.ortalama + "\t\t" + temp.durum);

            }
        }
        public void enBasarili()
        {
            if (head == null)
            {
                Console.WriteLine("Listede Kayıtlı Öğrenci Yok ");
            }
            else
            {
                Ogrenci temp = head;
                Ogrenci yuksekOgr = temp;
                float enyuksekOrtalama = head.ortalama;
                while (temp.next != null)
                {
                    if (enyuksekOrtalama < temp.ortalama)
                    {
                        enyuksekOrtalama = temp.ortalama;
                        yuksekOgr = temp;
                    }
                    temp = temp.next;
                }
                if (enyuksekOrtalama < temp.ortalama)
                {
                    enyuksekOrtalama = temp.ortalama;
                    yuksekOgr = temp;
                }
                Console.WriteLine("--- En Yüksek Ortalamalı Öğrenci Bilgileri ---");
                Console.WriteLine("Numara\t\tAd\t\tSoyad\t\tDers Adı\t\tOrtalama\t\tDurum\n");
                Console.WriteLine(yuksekOgr.numara + "\t\t" + yuksekOgr.ad + "\t\t" + yuksekOgr.soyad + "\t\t" + yuksekOgr.dersAdi + "\t\t" + yuksekOgr.ortalama + "\t\t" + yuksekOgr.durum);



            }
        }
    }
}







