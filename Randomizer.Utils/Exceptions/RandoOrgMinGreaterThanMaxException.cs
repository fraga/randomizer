using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Randomizer.Utils
{
    public class RandoOrgMinGreaterThanMaxException : Exception
    {
        public override string Message
        {
            get
            {
                return "Minimum number cannot exceed maximum number";
            }
        }
    }
}
