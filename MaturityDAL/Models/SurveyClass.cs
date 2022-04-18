using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaturityDAL.Models
{
    public class SurveyClass
    {
        public Question qstndetails { get; set; }
        public Answer ansdetails { get; set; }
        public Function functiondetails { get; set; }
    }
}
