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
		public GameObject Panel; 
		public Text txtName,txtPrice,txtCapacity,txtSpeed;
		private Sprite Plane;
		public Image PlaneImage;
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
                    foreach (var item in Object.Models)
                    {
                        PlaneImage.sprite = item.Image;
                    }
                }
			}
			catch (Exception e)
			{
				Debug.Log("Error:");
				Debug.Log(e.Message);
			}
		}

		// Update is called once per frame
		void Update ()
        {
		
		}
	}
}

