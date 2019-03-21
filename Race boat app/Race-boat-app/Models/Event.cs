﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Race_boat_app.Models
{
    public class Event
    {
        public string Id;

        public string VideoURL { get; set; }

        public string EventFileID { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }

        public string Location { get; set; }

        public string TimeStart { get; set; }

        public string TimeEnd { get; set; }

        public string Description { get; set; }
    }
}
