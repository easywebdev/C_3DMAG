using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _3DMAG_v1
{
    class Validator
    {
        public static string validate(List<ValidateData> data)
        {
            string errMsg = null;
            List<string> errList = new List<string>();

            foreach (ValidateData d in data)
            {
                d.ctrl.ForeColor = Color.Black;

                switch(d.type)
                {
                    case "int":
                        try
                        {
                            int.Parse(d.ctrl.Text);
                        }
                        catch
                        {
                            errList.Add(d.errMessage);
                            d.ctrl.ForeColor = Color.Red;
                        }
                        break;
                    case "double":
                        try
                        {
                            double.Parse(d.ctrl.Text);
                        }
                        catch
                        {
                            errList.Add(d.errMessage);
                            d.ctrl.ForeColor = Color.Red;
                        }
                        break;
                    case "byte":
                        try
                        {
                            Convert.ToByte(d.ctrl.Text, 16);
                        }
                        catch
                        {
                            errList.Add(d.errMessage);
                            d.ctrl.ForeColor = Color.Red;
                        }
                        break;
                }
            }

            if(errList.Count > 0)
            {
                for(int i = 0; i < errList.Count; i++)
                {
                    errMsg += (i + 1).ToString() + ". " + errList[i] + "\n";
                }
            }

            return errMsg;
        }
    }

    struct ValidateData
    {
        public Control ctrl { set; get; }
        public string type { set; get; }
        public string errMessage { set; get; }
    }
}
