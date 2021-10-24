using System;
using Util.Dtos.User;

namespace Util.Dtos
{
    public class ControlDto
    {
        public Guid Id { get; set; }
        public int ControlStateId { get; set; }
        public string ControlState { get; set; }
        public int AutomationLevelId { get; set; }
        public string AutomationLevel { get; set; }
        public int ControlTypeId { get; set; }
        public string ControlType { get; set; }
        public DateTime CreationDate { get; set; }
        public string Frequency { get; set; }
        public string Code { get; set; }
        public bool Documented { get; set; }
        public string Policy { get; set; }
        public string ResponsablePosition { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string Activity { get; set; }
        public string Objective { get; set; }
        public string Evidence { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
    }
}
