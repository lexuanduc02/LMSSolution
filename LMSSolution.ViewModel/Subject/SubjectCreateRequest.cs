using LMSSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.ViewModels.Subject
{
    public class SubjectCreateRequest
    {
        public string? Name { get; set; }
        public int? NumberOfLesson { get; set; }
        public List<int>? MajorId { get; set; }  = new List<int>();
    }
}
