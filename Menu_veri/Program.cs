using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Menu_veri
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            Liste ilkliste = new Liste();
            int secim;

            do
            {
                secim = Menu();

                switch (secim)
                {
                    case 1:
                        ilkliste.BasaEkle();
                        break;

                    case 2:
                        ilkliste.SonaEkle();
                        break;
                    
                    case 3:
                        ilkliste.sondanSil();
                        break;
                    case 4:
                        ilkliste.bastanSil();
                        break;
                    case 5:
                        ilkliste.arayaEkle();
                        break;
                    case 6:
                        ilkliste.aradanSil();
                        break;
                    case 7:
                        ilkliste.ListeSay();
                        break;
                    case 8: 
                        ilkliste.yazdir();
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                        break;
                }
            } while (secim != 0);
        }

        private static int Menu()
        {
            Console.WriteLine("İstediğiniz işlemi seçiniz:");
            Console.WriteLine("1--> Başa sayı ekleme");
            Console.WriteLine("2--> Sona sayı ekleme");
            Console.WriteLine("3--> Sondan silme");
            Console.WriteLine("4--> Baştan silme");
            Console.WriteLine("5--> Araya sayı ekleme");
            Console.WriteLine("6--> Aradan silme");
            Console.WriteLine("7--> Sayıları sayma");
            Console.WriteLine("8--> Yazdır");
            Console.WriteLine("0--> Çıkış");
            int secim = int.Parse(Console.ReadLine());
            return secim;
        }
    }
}