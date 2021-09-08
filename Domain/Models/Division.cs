using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Division
    {
        public Division(int divisionId, int areaId, Area area, int userProfileId, UserProfile userProfile, string name, string description, IEnumerable<Department> departments)
        {
            DivisionId = divisionId;
            AreaId = areaId;
            Area = area;
            UserProfileId = userProfileId;
            UserProfile = userProfile;
            Name = name;
            Description = description;
            Departments = departments;
        }

        public Division(){}

        [Key]
        public int DivisionId { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        
        public int? UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        
    }
}