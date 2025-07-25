namespace CoreMasterDetailsCRUD.Models
{
    public class CourseHeadCount
    {
        public int CourseId { get; set; }
        public int Count { get; set; }
        public virtual Course Course { get; set; }
        public string CourseName { get; set; }

    }
}
