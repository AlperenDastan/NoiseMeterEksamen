﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseMeterLib.Models
{
    public class NoiseMeter
    {
        public int Id { get; set; }
        public string? DeviceId { get; set; }
        public decimal? dBvolume { get; set; }
        public DateTime? Timestamp { get; set; }
        
    }
}
