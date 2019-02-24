using UnityEngine;

namespace Plane {
	public class Movement : MonoBehaviour {

		// put the points from unity interface
		public Transform[] wayPointList;
 
		public int currentWayPoint = 0; 
		Transform targetWayPoint;
 
		public float speed = 4f;
		
		//To let move the plane
		public static bool CanMove;

		// Update is called once per frame
		void Update() {
			
			// check if we have somewere to walk\
			if (CanMove) {
				if(currentWayPoint < wayPointList.Length)
				{
					if(targetWayPoint == null)
						targetWayPoint = wayPointList[currentWayPoint];
					Run();
				}
			}
		}

		void Run(){
			
			
			// rotate towards the target
			var dir = targetWayPoint.position - transform.position;
			var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
 
			// move towards the target
			transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position,   speed*Time.deltaTime);
 
			//Select the next path by the order
			if(transform.position == targetWayPoint.position)
			{
				if (currentWayPoint == 3) {
					currentWayPoint = 0;
				}
				else {
					currentWayPoint++;
				}
				targetWayPoint = wayPointList[currentWayPoint];
			}
		}

		void OnTriggerExit(Collider other) {
			CanMove = true;
		}
	}
}
