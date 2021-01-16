using BorderControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    public class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            Model = model;
            ID = id;
        }
        public string Model { get; set; }
        public string ID { get; private set; }
    }
}
