using System;
using System.Collections.Generic;

namespace CircularPlane.Plane.Models {
    [Serializable]
    public class Shop
    {
        public string Model { get; set; }
        public List<object> Details { get; set; }
    }

    public class RootObject
    {
        public List<Shop> Shop { get; set; }
    }
}