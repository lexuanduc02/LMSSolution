using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.Data.Enum
{
    public enum StudyShiff
    {
        [Description("06:45->09:00")]
        shiff_1,

        [Description("09:10 ->11:25")]
        shiff_2,

        [Description("12:45 ->15:00")]
        shiff_3,

        [Description("15:10 ->17:25")]
        shiff_4,

        [Description("17:30 ->20:15")]
        shiff_5,
    }
}
