namespace Util.Dtos
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public int EmployeeRolId { get; set; }
        public EmployeeRolDto EmployeeRol { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
    }
}