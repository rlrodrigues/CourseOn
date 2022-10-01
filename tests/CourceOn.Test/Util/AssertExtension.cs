using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseOn.Test.Util
{
    public static class AssertExtension
    {
        public static void WithMessage(this ArgumentException argumentException, string message)
        {
            if (argumentException.Message == message) Assert.True(true);
            else Assert.False(true);
        }
    }
}
