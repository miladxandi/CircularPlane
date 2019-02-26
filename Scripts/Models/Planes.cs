using System;
using System.Collections.Generic;

namespace CircularPlane.Plane.Models {
    [Serializable]
    public class Model
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public int Speed { get; set; }
    }

    [Serializable]
    public class RootObject
    {
        public Model[] Models { get; set; }
    }
}