using UnityEngine;
using UnityEngine.EventSystems;

namespace CircularPlane.Plane {
	public class DragDrop : MonoBehaviour, IDragHandler, IEndDragHandler,IDropHandler {
		

		//To get the drag result
		private float draged_x, draged_y;
		//To store the original value and new dragged position
		private Vector2 Draged;



		public void OnDrag(PointerEventData eventData) {
			transform.position = Input.mousePosition;
			Draged =  Input.mousePosition;
		}
		
		
		

		public void OnEndDrag(PointerEventData eventData) {
			//Sets the dragged position to check it
			Draged = new Vector2(draged_x, draged_y);
		}
		
		
		
		
		public void OnDrop(PointerEventData eventData) {
			if (eventData.pointerDrag != null) {
				draged_x = eventData.position.x;
				draged_y= eventData.position.y;
			}
		}
		
		
		

		
		
	}

}
