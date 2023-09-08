using System.ComponentModel.DataAnnotations.Schema;

namespace LinqPractises{
  public class Student{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // StudentId artık otomatik olarak artacak
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int ClassId { get; set; }

  }
}