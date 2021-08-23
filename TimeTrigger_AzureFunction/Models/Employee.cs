using System;

namespace TimeTrigger_AzureFunction.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime AddMinutes { get; set; }
    }
}
