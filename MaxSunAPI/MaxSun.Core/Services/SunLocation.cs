using MaxSun.Core.Interfaces;
using MaxSun.Model;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSun.Core.Services
{
    public class SunLocation : ISunLocation
    {
        public SunLocationData GetSunLocationData()
        {
            var scriptName = "SunLocation";
            //if (string.IsNullOrEmpty(scriptName))
            //{
            //    throw new ArgumentNullException("The script name is null or empty.");
            //}

            //Todo: store this in app settings
            Runtime.PythonDLL = @"C:\Users\IKECHUKWU\AppData\Local\Programs\Python\Python312\python312.dll";
            PythonEngine.Initialize();
            using (Py.GIL())
            {
                dynamic sys = Py.Import("sys");
                sys.path.append(@"C:\Users\IKECHUKWU\Desktop\Projects\max-sun\MaxSunAPI\MaxSun.Core\Services");
                var pythonScript = Py.Import(scriptName);
                var arr = pythonScript.InvokeMethod("sunLocation").ToString().Split(",");
                var result = new SunLocationData()
                {
                    Altitude = arr[0],
                    Azimuth = arr[1]
                };
                return result;

            }

        }
    }
}
