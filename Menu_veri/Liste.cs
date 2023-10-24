using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Menu_veri
{
    internal class Liste
    {
        Node head = null;
        
        public void BasaEkle()
        {
            Console.Write("Listeye Eklenecek Sayıyı Giriniz:");
           int  sayi=Convert.ToInt32(Console.ReadLine());

            Node eleman = new Node();
            eleman.data = sayi;

            if (head == null)
            {
                head = eleman;
                Console.WriteLine(head.data+"  ilk eleman olarak eklendi.");
            }

            else
            {
               eleman.next = head;
                head = eleman;
                
                Console.WriteLine(head.data+"  başa eklendi");
            }
        }

        public void SonaEkle()
        {
            
            Console.WriteLine("Sona eklemek istediğiniz sayıyı giriniz");
            int sayı= Convert.ToInt32(Console.ReadLine());

            Node eleman = new Node();
            eleman.data = sayı;
            if(head == null)
            {
                head = eleman;
                Console.WriteLine("liste boş olduğu için "+eleman.data+" ilk eleman olarak eklendi ");
            }

            else
            {
                Node temp= head;

                while(temp.next != null) { 
                    temp = temp.next;
                }
                temp.next = eleman;

                Console.WriteLine(eleman.data+"  sayısı sona eklendi");
            }
        }

        public void bastanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Eleman olmadığı için silemiyoruz.");
            }
            else
            {
                Console.WriteLine(head.data+" silindi");
                head = head.next;
                
            }
        }

        public void sondanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Eleman olmadığı için silemiyoruz.");
            }
            else if (head.next == null)
            {
                // Listenin sadece bir elemanı varsa, bu elemanı silin.
                Console.WriteLine(head.data + " silindi");
                head = null;
            }
            else
            {
                Node temp = head;
                Node temp2 = null;

                while (temp.next != null)
                {
                    temp2 = temp;
                    temp = temp.next;
                   
                }
                temp2.next = null;

                Console.WriteLine(temp.data + " silindi");
            }
        }

        public void yazdir()
        {
            Node temp = head;
            if (head == null)
            {
                Console.WriteLine("liste boş");
            }
            else
            {
                Console.Write("baş-->");
               
                while(temp.next != null)
                {
                    Console.Write(temp.data + "-->");
                    temp= temp.next;
                    
                }
                Console.Write(temp.data);
                Console.WriteLine("-->son");
            }
        }

        public void arayaEkle() 
        {
            Console.WriteLine("Sayıyı kaçıncı sıraya eklemek istersiniz?");
            int yer= Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("hangi sayıyı eklemek istersiniz?");
            int sayi= Convert.ToInt32(Console.ReadLine());
            Node temp = head;

            if (yer == 0)
            {
                Console.WriteLine("hatalı yer seçimi");
            }
            else 
            {
                for (int i = 1; i < yer - 1; i++)
                {
                    temp = temp.next;
                }
                Node eleman = new Node();
                eleman.data = sayi;
                eleman.next = temp.next;//eklediğim sayıdan sonra sayılar devam etsin diye 
                temp.next = eleman;//araya eklediğim kısım

                Console.WriteLine(yer + ".sıraya " + eleman.data + " yerleştirildi.");
            }
            

        }

        public void aradanSil()
        {
            Console.WriteLine(" kaçıncı sırayı silmek istersiniz?");
            int yer = Convert.ToInt32(Console.ReadLine());
            Node temp = head;
            Node temp2 = temp;

            if (yer == 0)
            {
                Console.WriteLine("hatalı yer seçimi");
            }
            else if (yer==1)
            {
                Console.WriteLine(head.data + " ilk eleman silindi");
                head = head.next;
               
            }
            else
            {
                for (int i = 0; i < yer-1; i++)
                {
                    temp2 = temp;
                    temp = temp.next;
                }
                if(temp2.next==null)
                {
                    Console.WriteLine(" o satırda eleman yok");
                }
                else
                {
                    temp2.next = temp.next;
                }
           
                Console.WriteLine(yer + ".sıradan " + temp.data + " çıkarıldı.");
            }
        }

        public void ListeSay()
        {
            Node temp = head;
            int sayac=1;
            while(temp.next != null)
            {
                temp=temp.next;
                sayac++;
            }
            Console.WriteLine("listede "+sayac+" sayı var.");
        }

    }
}
