using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTemplate.Models
{
    public class Student
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender? Gender { get; set; }

        public override string ToString()
        {
            return $"{ID}-{Name}-{Age}-{Gender?.ToString()}";
        }
    }

    public enum Gender
    { 
        Male,
        Female
    }
}
