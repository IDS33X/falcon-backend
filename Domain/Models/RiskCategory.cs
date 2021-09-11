namespace Domain.Models
{
    public class RiskCategory : BaseMaintenance
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
