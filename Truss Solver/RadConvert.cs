using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truss_Solver
{
    internal static class RadConvert
    {

        public static double ConvertToRad(double angleDegree)
        {
            return angleDegree * Math.PI / 180.0;

        }
    }
}

