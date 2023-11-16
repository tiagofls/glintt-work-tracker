﻿using GlinttWorkTracker.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlinttWorkTracker.Domain.Models
{
    public enum Type { Story, Defect, Bug };
    public class Issue : Entity
    {
        public Type Type { get; set; }
    }
}
