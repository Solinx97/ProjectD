namespace ViewDirectory.Models
{
    public class DataTransfer
    {
        public Faculties[] Faculties { get; set; }

        public Group[] Groups { get; set; }

        public GroupLoads[] GroupLoads { get; set; }

        public Load[] Loads { get; set; }

        public Subject[] Subjects { get; set; }

        public Teacher[] Teachers { get; set; }

        public UnitOfLoads[] UnitOfLoads { get; set; }
    }
}