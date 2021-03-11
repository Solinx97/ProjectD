namespace ViewDirectory.Models
{
    public class PlanTimes
    {
        public int Id { get; set; }

        public int PlanTimeTypeId { get; set; }

        public int TimePlan { get; set; }

        public int TimeFact { get; set; }

        public int TimeDiff { get; set; }

        public double SubjectPlan { get; set; }

        public int MonthId { get; set; }

        public int SubjectId { get; set; }
    }
}