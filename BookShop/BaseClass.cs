using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop
{
    public abstract class BaseClass
    {
        // magic string olmaması için değişkenlere atadık
        const int MIN_NUMS = 100000000; // minumum id değeri
        const int MAX_NUMS = 999999999; // maximum id değeri

        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

        Random random = new Random();

        public BaseClass()
        {
            // inherit edilen base/ parent sınıf ın constructor'ı daha önce çalışır
            // Console.WriteLine("BaseClass constructor");
            Id = random.Next(MIN_NUMS, MAX_NUMS);
            CreatedTime = DateTime.Now;
            UpdatedTime = DateTime.Now;
        }

        /// <summary>
        /// Overload method örneği
        /// </summary>
        /// /
        public virtual void MyOverloadMethod()
        {
            Console.WriteLine("");
        }
    }
}
