using System;
using System.Collections.Generic;

namespace DomainService.Models
{
    public class ClassModel
    {
        public Guid Id {get;set;}
        public string ClassName{get;set;}
        public ICollection<CourseModel> Course {get;set;}
        
    }
}
