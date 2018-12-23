namespace DataAccess.Models
{
    public class RecordData
    {
        public int RecordId { get; set; }

        public int Age { get; set; }

        public int WorkClassId { get; set; }

        public string WorkClass { get; set; }

        public int EducationLevelId { get; set; }

        public string EducationLevelName { get; set; }

        public string EducationLevel { get; set; }

        public int MaritalStatusId { get; set; }

        public string MaritalStatus { get; set; }

        public int OccupationId { get; set; }

        public string Occupation { get; set; }

        public int RelationshipId { get; set; }

        public string Relashionship { get; set; }

        public int RaceId { get; set; }

        public string Race { get; set; }

        public int SexId { get; set; }

        public string Sex { get; set; }

        public int CapitalGain { get; set; }

        public int CapitalLoss { get; set; }

        public int HoursPerWeek { get; set; }

        public int CountryId { get; set; }

        public string Country { get; set; }

        public bool IsOver50k { get; set; }
    }
}
