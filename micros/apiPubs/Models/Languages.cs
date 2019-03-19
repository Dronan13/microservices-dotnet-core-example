using System;
using System.Collections.Generic;

namespace apiCurriculum.Models
{
    public partial class Languages
    {
        public int LanguageId { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
