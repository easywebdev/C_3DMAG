using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _3DMAG_v1
{
    class Measure
    {
        /* Variables */
        Device device;
        MeasureSettings settings;
        /**/

        public Measure(Device device, MeasureSettings settings)
        {
            this.device = device;
            this.settings = settings;
        }

        /*
         * Function measure Temperature
         * Use two current direction
         */
        public double measureT()
        {
            double T = 0;
            double R = 0;
            double R1 = 0;
            double R2 = 0;

            device.selectSensor(4);
            device.setSensorCurrentValue(settings.pt100Current);
            device.setGains(settings.pt100Gain1 + settings.pt100Gain2);

            device.doSwitch("I13V24");
            R1 = device.getVoltageIEEE754();

            device.doSwitch("I31V24");
            R2 = device.getVoltageIEEE754();

            
            R = Math.Abs(R1 - R2) / 2 / settings.pt100Current * 1E3;
            T = ConversionFunction.linearConversion(R, settings.KT0, settings.KT1);

            return T;
        }

        /*
         * Function measure Hall voltage VH by spinning current technique
         * No use ABS
         */
        public double measureV()
        {
            double V = 0;
            double V1 = 0;
            double V2 = 0;
            double V3 = 0;
            double V4 = 0;

            // V1 (I24V31)
            device.doSwitch("I24V31");
            V1 = device.getVoltageIEEE754();

            // V2 (I31V42)
            device.doSwitch("I31V42");
            V2 = device.getVoltageIEEE754();

            // V3 (I42V31)
            device.doSwitch("I42V31");
            V3 = device.getVoltageIEEE754();

            // V4 (I13V42)
            device.doSwitch("I13V42");
            V4 = device.getVoltageIEEE754();

            V = (V1 + V2 - V3 - V4) / 4;

            return V;
        }
    }
}
