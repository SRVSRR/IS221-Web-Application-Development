namespace Lab7_StudentRegistration.Models
{
    public class Student
    {
        public string Stu_ID { get; set; } = string.Empty;
        public string Stu_Name { get; set; } = string.Empty;
        public string Stu_Passwd { get; set; } = string.Empty;
        public string Stu_Prog { get; set; } = string.Empty;
    }

    public class StuMajor
    {
        public int Id { get; set; }
        public string Stu_ID { get; set; } = string.Empty;
        public string Stu_Majors { get; set; } = string.Empty;
    }
}