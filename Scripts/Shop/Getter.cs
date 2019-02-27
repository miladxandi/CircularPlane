using System;
using UnityEngine;
using UnityEngine.UI;

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
                Repository.Get JsonObject = new Repository.Get();
                int Index = 0;
                foreach (var item in JsonObject.PlanesObject.Models)
                {
                    txtName[Index].text = item.Name;
                    txtPrice[Index].text = item.Price.ToString() + "$";
                    txtCapacity[Index].text = item.Capacity.ToString() + " PASS";
                    txtSpeed[Index].text = item.Speed.ToString() + " KM/H";
                    PlaneImage[Index].sprite = Planes[Index];
                    Index++;
                }
            }
            catch (Exception e)
            {
                Debug.Log("Error:");
                Debug.Log(e.Message);
            }
		}
	}
}

