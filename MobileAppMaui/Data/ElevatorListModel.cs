﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppMaui.Data
{
    public enum ElevatorStatus
    {
        Disabled /*Elevator off, doors closed*/,
        Idle /*Elevator on, doors closed, not running*/,
        Running /*Elevator on, doors closed, running*/,
        Error /*Elevator error*/
    }
    public class ElevatorListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ElevatorStatus Status { get; set; }
        public bool DoorStatus { get; set; }
        public int CurrentLevel { get; set; }
        public int TargetLevel { get; set; }

        public string Url
        {
            get { return "ElevatorDetails/" + this.Id; }
        }
    }
}
