namespace ViewDirectory.Models
{
    public class PlanTimeType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TotalPlanTime { get; set; }

        public int FactPlanTime { get; set; }

        public int DiffPlanTime { get; set; }

        public int TermId { get; set; }

        public int RowId { get; set; }
    }
}