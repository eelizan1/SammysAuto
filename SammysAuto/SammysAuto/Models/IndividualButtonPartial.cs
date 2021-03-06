﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SammysAuto.Models
{
    public class IndividualButtonPartial
    {
        // properties that the view uses
        public string ButtonType { get; set; }
        public string Action { get; set; }
        public string Glyph { get; set; }
        public string Text { get; set; }

        public int? ServiceId { get; set; }

        public string ActionParameters
        {
            get
            {
                var param = new StringBuilder(@"/"); 
                if(ServiceId != 0 && ServiceId != null)
                {
                    param.Append(String.Format("{0}", ServiceId));
                }

                return param.ToString().Substring(0, param.Length);
            }
        }
    }
}
