namespace ViewDirectory.Models
{
    public class Row
    {
        public Subject Subject { get; set; }

        public Group[] Group { get; set; }

        public Cell[] Cells { get; set; }

        public double TotalHours { get; set; }

        public int StudentsCount { get; set; }

        public int Term { get; set; }

        public string FacultyName { get; set; }
    }
}