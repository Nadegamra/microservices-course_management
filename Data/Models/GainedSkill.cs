﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagement.Data.Models
{
    public class GainedSkill
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("Skill")]
        public int? SkillId { get; set; }
        public Skill? Skill { get; set; }
        public string? CustomDescription { get; set; }
    }
}
