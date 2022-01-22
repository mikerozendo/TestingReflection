using System;
using System.Text;

namespace TestingReflection.Domain
{
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int YearsOld { get; set; }
        public string Email { get; set; }

        public Person()
        {
            Name = "Michael";
            LastName = "Rozendo";
            YearsOld = 23;
            Email = "mikerozendo@gmail.com";
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"=======================================");
            sb.AppendLine($"Person's name: {Name}");
            sb.AppendLine($"Years old: {YearsOld}");
            sb.AppendLine($"BirthDate: {DateTime.Now.AddYears(-YearsOld)}");
            sb.AppendLine($"Email: {Email}");
            sb.AppendLine($"=======================================");
            return sb.ToString();
        }

        public bool IsOldEnough(int yearsOld)
        {
            return DateTime.Now.Year - DateTime.Now.AddYears(-yearsOld).Year > 18 ? true : false;
        }
    }
}
