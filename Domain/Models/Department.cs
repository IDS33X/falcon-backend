using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Department
    {
        public Department(int departmentId, int divisionId, Division division, string name, string description, IEnumerable<UserProfile> userProfile)
        {
            DepartmentId = departmentId;
            DivisionId = divisionId;
            Division = division;
            Name = name;
            Description = description;
            UserProfiles = userProfile;
        }

        public Department(){}

        [Key]
        public int DepartmentId { get; set; }
        public int DivisionId { get; set; }
        public Division Division { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<UserProfile> UserProfiles { get; set; }
    }
}