using UnityEngine.UI;
using UnityEngine;
using System;

public class HighScore : MonoBehaviour
{

    [SerializeField] private FileManager fm;
    private int _highScore;

    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        Debug.Log("About to call GetHighScore");
        _highScore = Int32.Parse(fm.GetHighScore());
        Display(0);
    }

    public void Display(int op)
    {
        _highScore += op;

        //Pad with ZEROs up to 8 digits
        string _highScoreStr = _highScore.ToString("D8");

        GetComponentInChildren<Text>().text = "HIGH SCORE: " + _highScoreStr;
    }
}
