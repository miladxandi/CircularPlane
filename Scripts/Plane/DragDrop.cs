using UnityEngine;
using UnityEngine.EventSystems;

namespace Plane {
	public class DragDrop : MonoBehaviour, IDragHandler, IEndDragHandler,IDropHandler {
		
		//To get the drag result
		public float draged_x, draged_y;
		
		
		//To store the original value and new dragged position
		private Vector2 OriginalPosition = new Vector2(-227,46),NewPostion = new Vector2(28,181.5f),Draged;

		public void OnDrag(PointerEventData eventData) {
			transform.position = Input.mousePosition;
			Movement.CanMove=false;
		}

		public void OnEndDrag(PointerEventData eventData) {
			
			//Sets the dragged position to check it
			Draged = new Vector2(draged_x, draged_y);
			
			//Check if it`s in the range
			if (Vector2.Distance(Draged , new Vector2(-227,46)) >= 615 && Vector2.Distance(Draged , new Vector2(-227,46)) <= 650) {
				Vector2 Dragged = OriginalPosition;
				transform.localPosition = Dragged;
				Movement.CanMove=false;
				Debug.Log(Vector2.Distance(OriginalPosition,Draged));
			}
			else {
				Vector2 Dragged = NewPostion;
				transform.localPosition = Dragged;
				Movement.CanMove=true;
				Debug.Log(Vector2.Distance(OriginalPosition,Draged));
			}
			
		}

		public void OnDrop(PointerEventData eventData) {
			if (eventData.pointerDrag != null) {
				draged_x = eventData.position.x;
				draged_y= eventData.position.y;
			}
		}
	}

}
