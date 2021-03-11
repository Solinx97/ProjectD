namespace ViewDirectory.Models
{
    public class IndividualPlanOnTerm
    {
        public OtherBids[] Bids { get; set; }

        public Faculties[] Faculties { get; set; }

        public OtherGroup[] Groups { get; set; }

        public Month[] Months { get; set; }

        public PlanTimeType[] PlanTimeTypes { get; set; }

        public PlanTimes[] PlanTimes { get; set; }

        public OtherSubject[] Subjects { get; set; }

        public OtherTeacher[] Teachers { get; set; }

        public Term[] Terms { get; set; }
    }
}