namespace ViewDirectory.Models
{
    public class DataTransfer
    {
        public Faculties[] Faculties { get; set; }

        public Groups[] Groups { get; set; }

        public GroupLoads[] GroupLoads { get; set; }

        public Loads[] Loads { get; set; }

        public Subjects[] Subjects { get; set; }

        public Teachers[] Teachers { get; set; }

        public UnitOfLoads[] UnitOfLoads { get; set; }
    }
}