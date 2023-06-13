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
        public Grade(double value, string subject)
        {
            Value = value;
            Subject = subject;
        }

        public string Subject { get; set; }
        public double Value { get; set; }
        public object DateTime { get; internal set; }
    }
}
