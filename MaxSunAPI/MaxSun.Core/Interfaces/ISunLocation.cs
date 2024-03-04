using MaxSun.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSun.Core.Interfaces
{
    public interface ISunLocation
    {
        SunLocationData GetSunLocationData();
    }
}
