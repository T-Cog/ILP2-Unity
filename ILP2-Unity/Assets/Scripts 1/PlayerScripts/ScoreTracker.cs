using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public float score;

    //Declares a text variable to draw score to the UI Canvas
    public Text scoreDisplay;

    void Update()
    {
        //Defines the display variable and converts the score float to a string
        scoreDisplay.text = "Score: " + score.ToString();
    }

    //Adds score to the score variable when a true bool is passed to the function
    void AddScore(bool add)
    {
        if(add == true)
        {
            score++;
            add = false;
        }
    }
}
