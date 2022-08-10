namespace DomainService.Models
{
    public class StudentModel
    {
        public Guid Id { get; set; }
        public PersonModel Person { get; set; }
        public string StudentNumber { get; set; }
        public int AcademicLevel { get; set; }
        public CourseModel Course { get; set; }
        
    }
}
