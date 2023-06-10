using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsCatalog
{
    /// <summary>
    /// Represents a grade.
    /// </summary>
    class Grade
    {
        public double Value { get; set; }
        public DateTime DateTime { get; set; }
        public string Subject { get; set; }

        public Grade(double value, string subject)
        {
            Value = value;
            DateTime = DateTime.Now;
            Subject = subject;
        }
    }
}
