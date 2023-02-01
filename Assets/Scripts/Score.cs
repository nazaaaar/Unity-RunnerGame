using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text text; 
    private int score=0;
    private static Score instance;
    public Text scoreText;
    public Camera cam;

    public Color color1;
    public Color color2;

    private void Start()
    {
        instance = this;
        text = gameObject.GetComponent<Text>();
    }
    private void _AddScore()
    {
        text.text = "score: " + ++score;

        if (score % 5 == 0 && cam.backgroundColor == color2)
        {
            cam.backgroundColor = color1;
        } else if (score % 5 == 0 ) cam.backgroundColor = color2;
    }

    public static void AddScore()
    {
        instance._AddScore();
    }

    private void _getScore()
    {
        scoreText.text = score.ToString();
    }

    public static void GetScore()
    {
        instance._getScore();
    }
}
