using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace CircularPlane.Plane.Shop {
	
	public class Getter : MonoBehaviour {
		public GameObject Panel; 
		public Text Name,Cost,Capacity,Speed;
		public Sprite Plane;
		public Image PlaneImage;
		// Use this for initialization
		void Start () {
//			Models.Shop oShop = new Models.Shop();
//			try {
//				string FileData = "Shop.json";
//				string filePath = Path.Combine(Application.streamingAssetsPath,FileData);
//				if (File.Exists((filePath))) {
//					string dataAsJson = File.ReadAllText(filePath);
//					var Object = JsonUtility.FromJson<Models.Shop>(dataAsJson);
//					Debug.Log(Object.Model); 
//				}
//			}
//			catch (IOException e)
//			{
//				Debug.Log("The file could not be read:");
//				Debug.Log(e.Message);
//			}
		}
		// Update is called once per frame
		void Update () {
		
		}
	}
}

