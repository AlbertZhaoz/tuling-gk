using HslCommunication.Profinet.Siemens;
using System;

namespace TulingHsl.Models
{
    public abstract class DeviceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}