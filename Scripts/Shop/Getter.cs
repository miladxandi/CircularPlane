using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using CircularPlane.Plane.Models;
using Newtonsoft.Json;

namespace CircularPlane.Plane.Shop {
	
	public class Getter : MonoBehaviour {
		public Button[] Item;
        public Canvas Canvas;
		public Text[] txtName,txtPrice,txtCapacity,txtSpeed;
		public Sprite[] Planes;
		public Image[] PlaneImage;
		// Use this for initialization
		void Start ()
        {
			try
            {
				string FileData = "Shop.json";
				string filePath = Path.Combine(Application.streamingAssetsPath,FileData);
				if (File.Exists((filePath)))
                {
                    string Json = File.ReadAllText(filePath);
                    var Object = JsonConvert.DeserializeObject<RootObject>(Json);
                    int Index = 0;
                    foreach (var item in Object.Models)
                    {
                        txtName[Index].text = item.Name;
                        txtPrice[Index].text = item.Price.ToString() + "$";
                        txtCapacity[Index].text = item.Capacity.ToString() + " PASS";
                        txtSpeed[Index].text = item.Speed.ToString()+" KM/H";
                        PlaneImage[Index].sprite = Planes[Index];
                        Index++;
                    }
                }
			}
			catch (Exception e)
			{
				Debug.Log("Error:");
				Debug.Log(e.Message);
			}
		}
        public void Notification()
        {

        }
	}
}

