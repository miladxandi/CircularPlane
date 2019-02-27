using CircularPlane.Plane.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

namespace CircularPlane.Plane.Repository
{
    public class Get : MonoBehaviour
    {
        public RootObject PlanesObject { get; set; }
        public Model Model { get; set; }
        public Get()
        {
            PlanesObject = Planes();
        }
        public Get(string ByName)
        {
            foreach (var item in Planes().Models)
            {
                if (item.Name == ByName)
                {
                    Model =  item;
                }
            }
        }
        private RootObject Planes()
        {
            try
            {
                string FileData = "Shop.json";
                string filePath = Path.Combine(Application.streamingAssetsPath, FileData);
                string Json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<RootObject>(Json);
            }
            catch (Exception e)
            {
                Debug.Log("Error:");
                Debug.Log(e.Message);
                return null;
            }
        }
    }
}