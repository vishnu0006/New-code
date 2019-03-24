using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Race_boat_app.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Team
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id;

        /// <summary>
        /// 
        /// </summary>
        public string CaptainID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PitID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Recruiting { get; set; }
    }
}
