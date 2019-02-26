using UnityEngine;

namespace CircularPlane.Plane {
	public class Movement : MonoBehaviour {

		// put the points from unity interface
		public Transform[] wayPointList;
 
		public int currentWayPoint = 0; 
		Transform targetWayPoint;
 
		public float speed = 3f;

        public Canvas Canvas;
        public GameObject StartPoint;

        //To let move the plane
        public bool CanMove;

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
			var Route = targetWayPoint.position - transform.position;
			var Angle = Mathf.Atan2(Route.y, Route.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
 
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.childCount <= 10)
            {
                //
                gameObject.transform.position = new Vector2(other.transform.position.x, other.transform.position.y);
                gameObject.transform.parent = other.transform;
                CanMove = false;
            }

        }


        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.transform.childCount <= 10)
            {
                gameObject.transform.position = new Vector2(other.transform.position.x, other.transform.position.y);
                gameObject.transform.parent = other.transform;
                CanMove = false;
            }
        }





        private void OnTriggerExit2D(Collider2D other)
        {
            transform.parent = Canvas.transform;
            transform.position = new Vector2(StartPoint.transform.position.x, StartPoint.transform.position.y);
            CanMove = true;
            currentWayPoint = 0;
            targetWayPoint = wayPointList[currentWayPoint];
        }
    }
}
