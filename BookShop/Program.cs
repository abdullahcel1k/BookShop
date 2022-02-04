using System;

namespace BookShop
{

    class Program
    {
        /// <summary>
        /// Kitap Mağazası Uygulaması
        ///
        /// Kitap, Kasa
        ///
        /// 1 - kitap kayıt edebilmeyi
        ///     -- kayıt esnasında kitap adi, adedi, maliyet fiyati, vergisi, kazanç miktari vs.
        ///     -- ürün fiyati maliyet fiyati, vergi ve kazanç miktarina bağlı olarak hesaplanır
        /// 2 - kitap silebilme
        ///     -- kita silme fonksiyonu seçilirse girilen adet kadar kitap silinecektir
        /// 3 - kitap güncelleme
        /// 4 - kitap satış
        ///     -- satılan kitap fiyatı kasaya gelir olarak giriş yapılır
        ///     -- satılan kitap kitap listemden eksiltilir
        /// 5 - kitap listesi
        /// 6 - kitap listesinden arama kabiliyeti
        ///
        ///  Kitap -> id, adi, tür'ü (enum kullanacağız), maliyet fiyati, toplam vergi, stok adedi, kayit tarihi, güncelleme tarihi
        ///  Kasa işlemi -> id, tür (gelir , gider (enum kullanacağım)), tutar, kayit tarihi
        ///  
        /// Kitap ve kasa haraketlerini txt dosyasını kaydedip daha sonra uygulama kapatılsada 
        /// bu bilgilerin unutulmamasını sağlamak 
        /// faydalı link : https://www.w3schools.com/cs/cs_files.php
        /// 
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int secim = 0;
            while (secim != 8)
            {
                Console.WriteLine("1 - Kitap Ekle");
                Console.WriteLine("2 - Kitap Silme");
                Console.WriteLine("3 - Kitap Güncelleme"); // öğrenciler yapıcak
                Console.WriteLine("4 - Kitap Satış");
                Console.WriteLine("5 - Kitap Listeleme");
                Console.WriteLine("6 - Kitap Ara"); // öğrencilere bırakıldı
                Console.WriteLine("7 - Kasa Haraketleri");
                Console.WriteLine("8 - Çıkış");
                secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        kitapEkleCase();
                        break;
                    case 2:
                        kitaplariListele();
                        Console.Write("Silmek istediğiniz kitap idsi:");
                        int bookId = Convert.ToInt32(Console.ReadLine());
                        Book.removeBook(bookId);
                        break;
                    case 4:
                        kitaplariListele();
                        Console.Write("Satılan kitap id'si:");
                        int satilanKitapId = Convert.ToInt32(Console.ReadLine());
                        
                        Console.Write("Kitap Adeti:");
                        int satilanKitapAdeti = Convert.ToInt32(Console.ReadLine());

                        Book.sellBook(satilanKitapId, satilanKitapAdeti);
                        kitaplariListele();
                        break;
                    case 5:
                        kitaplariListele();
                        break;
                    case 7:
                        CaseTransaction.kasaHaraketleriniListele();
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("KASA HAREKETLERİ");
            foreach (CaseTransaction caseTransaction in CaseTransaction.CaseTransactions)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine(caseTransaction.ToString());
            }
        }

        public static void kitapEkleCase()
        {
            // Kitap ekleme
            // adı, maliyet fiyati, türü, tax, kazanç miktari, adet

            // kitap adi
            Console.Write("Kitap Adi:");
            string bookName = Console.ReadLine();

            // kitap maliyeti
            Console.Write("Maliyet:");
            double costPrice = Convert.ToDouble(Console.ReadLine());

            // kitap türü
            Console.Write("Türü(0-4):");
            BookTypeEnums bookType = (BookTypeEnums)Convert.ToInt32(Console.ReadLine());

            // vergi orani
            Console.Write("Vergi Oranı:");
            int taxPercantage = Convert.ToInt32(Console.ReadLine());

            // kazanç orani
            Console.Write("Kazanç Oranı:");
            int profitMargin = Convert.ToInt32(Console.ReadLine());

            // adet
            Console.Write("Adet:");
            int qty = Convert.ToInt32(Console.ReadLine());

            Book newBook = new Book(bookName, costPrice, bookType, taxPercantage, profitMargin, qty);
            Book.addBook(newBook);
        }
    
        public static void kitaplariListele()
        {
            Console.WriteLine("KİTAP LİSTESİ");
            foreach (Book item in Book.Books)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine(item.ToString());
            }
        }
    }
}
