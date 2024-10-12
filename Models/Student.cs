namespace FluentWay.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public required User User { get; set; }
        public required Course Course { get; set; }
    }
}
