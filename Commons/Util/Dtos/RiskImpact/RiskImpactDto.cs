namespace Util.Dtos.RiskImpact
{
    public class RiskImpactDto
    {
        public int Id { get; set; }
        public int ImpactTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Severity { get; set; }
        public int Probability { get; set; }

    }
}
