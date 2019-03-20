using System;
using System.Collections.Generic;

namespace apiCurriculum.Models
{
    public partial class Skills
    {
        public int SkillId { get; set; }
        public string Skill { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
