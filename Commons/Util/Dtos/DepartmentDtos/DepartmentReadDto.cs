namespace Util.Dtos.DepartmentDtos
{
    public class DepartmentReadDto
    {
        public int Id { get; set; }
        public int DivisionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CountAnalytics { get; set; }

    }
}