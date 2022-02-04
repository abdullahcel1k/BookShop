using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop
{
    // Kasa hareketleri
    class CaseTransaction : BaseClass
    {
        public static List<CaseTransaction> CaseTransactions = new List<CaseTransaction>();
        public double Amount { get; set; }  // tutar
        public TransactionTypeEnums TransactionType { get; set; }

        // CaseTransaction sınıfımın constructor
        // yapıcı metot
        public CaseTransaction(double _amount,
            TransactionTypeEnums _transactionType) 
        {
            Amount = _amount;
            TransactionType = _transactionType;
        }

        // kasa işlemi kaydetme metodum
        public static void saveCaseTransaction(CaseTransaction caseTransaction)
        {
            CaseTransactions.Add(caseTransaction);
        }

        public static double calculateAmount(double price, int qty)
        {
            return price * qty;
        }

        public static void kasaHaraketleriniListele()
        {
            Console.WriteLine("KASA HAREKETLERİ");
            double kasaToplam = 0; 
            foreach(CaseTransaction kasaHareketi in CaseTransactions)
            {
                Console.WriteLine("-------------------");
                if (kasaHareketi.TransactionType == TransactionTypeEnums.EXPENSE)
                {
                    kasaToplam -= kasaHareketi.Amount;
                }
                else
                {
                    kasaToplam += kasaHareketi.Amount;
                }
                Console.WriteLine(kasaHareketi.ToString());
            }
            Console.WriteLine("Kasa Toplam Tutarı : " + kasaToplam);
        }

        public override string ToString()
        {
            return String.Format("Id: {0} - Type: {1} - " +
                "Amount: {2} - Crated Time: {3}",
                Id, TransactionType, Amount,CreatedTime);
        }
    }
}
