using MCTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCTools
{
    public class TemplateUtils
    {

        public static int GetTemplate(int nOfQuestion)
        {
            switch (nOfQuestion)
            {
                case 45:
                    return Constant.TEMPLATE_45_QUESTIONS;
                case 60:
                    return Constant.TEMPLATE_60_QUESTIONS;
                case 80:
                    return Constant.TEMPLATE_80_QUESTIONS;
                case 100:
                    return Constant.TEMPLATE_100_QUESTIONS;
                default:
                    return -1;
            }
        }

        public static int GetNumberOfVerticalFLagRect(int type)
        {
            switch (type)
            {
                case Constant.TEMPLATE_100_QUESTIONS:
                    return 37;
                case Constant.TEMPLATE_80_QUESTIONS:
                    return 32;
                case Constant.TEMPLATE_60_QUESTIONS:
                    return 32;
                case Constant.TEMPLATE_45_QUESTIONS:
                    return 27;
                default:
                    return -1;
            }
        }

        public static int GetNumberOfHorizontalFLagRect(int type)
        {
            switch (type)
            {
                case Constant.TEMPLATE_100_QUESTIONS:
                    return 21;
                case Constant.TEMPLATE_80_QUESTIONS:
                    return 21;
                case Constant.TEMPLATE_60_QUESTIONS:
                    return 16;
                case Constant.TEMPLATE_45_QUESTIONS:
                    return 16;
                default:
                    return -1;
            }
        }
    }
}
