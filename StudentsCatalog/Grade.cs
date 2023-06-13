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

        public object DateTime { get; internal set; }
    }
}
