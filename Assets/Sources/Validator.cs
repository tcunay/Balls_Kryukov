using System;
using System.Linq;

namespace Sources
{
    public class Validator
    {
        public static void Validate(params bool[] conditions)
        {
            if (conditions.Any(condition => condition))
            {
                throw new InvalidOperationException();
            }
        }
    }
}