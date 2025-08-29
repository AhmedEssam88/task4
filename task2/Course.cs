namespace task2
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Instructor Instructor { get; set; }
        public Course(int id, string title, Instructor instructor)
        {
            Id = id;
            Title = title;
            Instructor = instructor;
        }
        public string PrintDetails()
        {
            return $"CourseID {Id} , Title : {Title}";
        }

    }
}