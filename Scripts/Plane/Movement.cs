using CircularPlane.Models;
using UnityEngine;
using UnityEngine.UI;

namespace CircularPlane.Plane {
	public class Movement : MonoBehaviour {

		// put the points from unity interface
		public Transform[] wayPointList;
 
		public int currentWayPoint = 0; 

		Transform targetWayPoint;
 
		public float speed = 3f;

        public Canvas Canvas;

        //The point we have to start
        public GameObject StartPoint;

        //Score Text
        public Text ScoreText;

        //To let move the plane
        public bool CanMove;

        private void Start()
        {
            //Define the special speed of every plane
            Repository.Get JsonObject = new Repository.Get(gameObject.name);
            speed = JsonObject.Model.Speed;
            ScoreText.text = PlayerPrefs.GetInt("Score").ToString();
            Screen.autorotateToPortrait = true;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

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

        //Put it on the parking lot
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Parking")
            {
                if (other.transform.childCount <= 0)
                {

                    gameObject.transform.position = new Vector2(other.transform.position.x, other.transform.position.y);
                    gameObject.transform.parent = other.transform;
                    CanMove = false;
                }
            }
        }

        //Hold it on the parking lot
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.tag == "Parking")
            {
                if (other.transform.childCount <= 0)
                {

                    gameObject.transform.position = new Vector2(other.transform.position.x, other.transform.position.y);
                    gameObject.transform.parent = other.transform;
                    CanMove = false;
                }
            }
        }

        //Put it on the race
        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.tag=="Parking")
            {
                transform.parent = Canvas.transform;
                transform.position = new Vector2(StartPoint.transform.position.x, StartPoint.transform.position.y);
                CanMove = true;

                //Force the planes to start from the first way point
                currentWayPoint = 0;
                targetWayPoint = wayPointList[currentWayPoint];
            }
            else if(other.tag== "End")
            {
                Scores Score = new Scores();
                Score.ScoreChange();
                ScoreText.text = PlayerPrefs.GetInt("Score").ToString();
            }
        }
    }
}
