using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public Text ScoreText;

    // Use this for initialization
    void Start ()
    {
        ScoreText.text = "Score is: " + GameController.Score;
    }
	
}
