using System;
using System.Linq;

namespace Sources
{
    public static class Validator
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