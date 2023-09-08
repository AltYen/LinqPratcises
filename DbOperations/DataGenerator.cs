using System.Linq;

namespace LinqPractises.DbOperations{
  public class DataGenerator{
    public static void Initialize(){
      using (var context = new LinqDbContext()){
        if(context.Students.Any()){
          return;
        }

        context.Students.AddRange(
          new Student(){
            Name = "Ayse",
            Surname = "Yılmaz",
            ClassId = 1
          },
           new Student(){
            Name = "Deniz",
            Surname = "Arda",
            ClassId = 1
          },
          new Student(){
            Name = "Umut",
            Surname = "Arda",
            ClassId = 2
          },
          new Student(){
            Name = "Merve",
            Surname = "Caliskan",
            ClassId = 2
          }
        );

        context.SaveChanges();
      }
    }
  }
}