using System;
using System.Linq;
using LinqPractises.DbOperations;

namespace LinqPractises
{
    class Program
    {
        static void Main(string[] args)
        {
            DataGenerator.Initialize();
            LinqDbContext _context = new LinqDbContext();
            var students = _context.Students.ToList<Student>();

            //Linq() => Find | primary key olan alana göre basit bir arama yapmaya sağlayan yapı.
            Console.WriteLine("******Find********");
            var student = _context.Students.Where(student => student.StudentId == 1).FirstOrDefault(); // ilk kaydı getirme;
            Console.WriteLine(student.Name);
            student = _context.Students.Find(2); // ilk kaydı getirme farklı yöntem;
            Console.WriteLine(student.Name);

            //FirstOrDefault() => birden fazla sonuç döneceği durumlarda ilk sonucu getir. Firstten farkı hiç değer bulamassa geriye null döner.
            Console.WriteLine();
            Console.WriteLine("****** FirstOrDefault *******");
            student = _context.Students.Where(student=>student.Surname == "Arda").FirstOrDefault();
            Console.WriteLine(student.Name);

            student = _context.Students.FirstOrDefault(x=> x.Surname == "Arda");
            Console.WriteLine(student.Name);

            //SingleOrDefault() => bir yada 0 veri bekler, 2 tane veri gelirse hata fırlatır. bunu kullanırken where den 1 tane veri döneceğinden emin olunmalı
            Console.WriteLine();
            Console.WriteLine("****** SingleOrDefault *******");
            student = _context.Students.SingleOrDefault(student => student.Name == "Deniz");
            Console.WriteLine(student.Surname);


            //ToList()
            Console.WriteLine();
            Console.WriteLine("****** ToList *******");
            var studentList = _context.Students.Where(student => student.ClassId == 2).ToList();
            Console.WriteLine(studentList.Count);

            //OrderBy();
            Console.WriteLine();
            Console.WriteLine("****** OrderBy *******");
            
            students = _context.Students.OrderBy(x=>x.StudentId).ToList();
            foreach(var st in students)
            {
                Console.WriteLine(st.StudentId + " - " + st.Name + " " + st.Surname);
            }

            //OrderByDescending();
            Console.WriteLine();
            Console.WriteLine("****** OrderByDescending *******");
            
            students = _context.Students.OrderByDescending(x=>x.StudentId).ToList();
            foreach(var st in students)
            {
                Console.WriteLine(st.StudentId + " - " + st.Name + " " + st.Surname);
            }


            //Anonymous Object Result
            Console.WriteLine();
            Console.WriteLine("****** Anonymous Object Result *******");

            var anonymousObject = _context.Students.Where(x=>x.ClassId == 2) // Yakaladığı sonuçlardaki verileri kullanarak farkli bir obje çıktısı verme
                                                   .Select(x=>new {
                                                     Id=x.StudentId,
                                                     Fullname= x.Name + " " + x.Surname
                                                   });
            
            foreach(var obj in anonymousObject)
            {
                Console.WriteLine(obj.Id + " - " + obj.Fullname);
            }
            


            Console.ReadKey();
        }
    }
}
