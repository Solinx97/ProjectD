namespace ViewDirectory.Models
{
    public class UnitOfLoads
    {
        public int Id { get; set; }

        public int LoadId { get; set; }

        public int TeacherId { get; set; }

        public double Value { get; set; }

        public int SubjectId { get; set; }

        public int Term { get; set; }

        public int Row { get; set; }

        public int StudentsCount { get; set; }
    }
}