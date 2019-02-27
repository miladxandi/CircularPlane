using UnityEngine;
using UnityEngine.UI;

namespace CircularPlane.Models
{
    public class Scores
    {
        private int Score;
        public void ScoreChange(bool Increment = true,int PlaneType=0)
        {
            if (Increment)
            {
                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
            }
            else
            {
                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - 1);
            }

        }
    }
}
