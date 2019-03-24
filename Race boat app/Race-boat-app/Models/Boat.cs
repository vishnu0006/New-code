using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Race_boat_app.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Boat
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id;

        /// <summary>
        /// 
        /// </summary>
        public string Beam { get; set; } // 17.3 in (440mm)

        /// <summary>
        /// 
        /// </summary>
        public string BeamM { get; set; } // in 

        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; } //Catamaran

        /// <summary>
        /// 
        /// </summary>
        public string DriveSystem { get; set; } //Flex shaft

        /// <summary>
        /// 
        /// </summary>
        public string HullHeight { get; set; } //9.5 in (241mm)

        /// <summary>
        /// 
        /// </summary>
        public string HullHeightM { get; set; } // in 

        /// <summary>
        /// 
        /// </summary>
        public string HullMaterial { get; set; } //Fiberglass

        /// <summary>
        /// 
        /// </summary>
        public string Length { get; set; } //48 in (1245mm)

        /// <summary>
        /// 
        /// </summary>
        public string LengthM { get; set; } // in 

        /// <summary>
        /// 
        /// </summary>
        public string MotorSize { get; set; } //6-pole 1000Kv 56×87mm

        /// <summary>
        /// 
        /// </summary>
        public string PropellerSize { get; set; } //1.4×1.90 and 1.4×2.0

        /// <summary>
        /// 
        /// </summary>
        public string Radio { get; set; } //Spektrum DX2E

        /// <summary>
        /// 
        /// </summary>
        public string Scale { get; set; }  //48-inch

        /// <summary>
        /// 
        /// </summary>
        public string ScaleM { get; set; }  // inch

        /// <summary>
        /// 
        /// </summary>
        public string Speed { get; set; } //55+ mph with 8S Li-Po

        /// <summary>
        /// 
        /// </summary>
        public string SpeedM { get; set; } // mph 

        /// <summary>
        /// 
        /// </summary>
        public string SpeedControl { get; set; } //Dynamite 160A HV 2S-8S

        /// <summary>
        /// 
        /// </summary>
        public string Steering { get; set; } //In-line rudder with break away

        /// <summary>
        /// 
        /// </summary>
        public string Coluors { get; set; } //Orange, Gray, White

        /// <summary>
        /// 
        /// </summary>
        public string Weight { get; set; } //12.5 lb(7.5kg)

        /// <summary>
        /// 
        /// </summary>
        public string WeightM { get; set; } // lb

        /// <summary>
        /// 
        /// </summary>
        public string CaptainID { get; set; }
    }
}
