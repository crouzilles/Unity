using UnityEngine.UI;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private FileManager fm;
    [SerializeField] private GameObject _triesObject;
    [SerializeField] private int _maxTries;
    private int _triesLeft;

    [SerializeField] private GameObject _highScoreObject;
    private int _highScore;

    [SerializeField] private GameObject _scoreObject;


    // Start is called before the first frame update
    void Start()
    {
        ResetTries();
        ResetHighScore();
    }

#region Tries
    public void ResetTries()
    {
        _triesLeft = _maxTries;
        DisplayTries(0);
    }

    public void DisplayTries(int op)
    {
        _triesLeft += op;
        _triesObject.GetComponentInChildren<Text>().text = "TRIES: " + _triesLeft + "/" + _maxTries;
    }
    #endregion Tries

    #region HighScore
    public void ResetHighScore()
    {
        _highScore = Int32.Parse(fm.GetHighScore());
        DisplayHighScore(0);
    }

    public void DisplayHighScore(int op)
    {
        _highScore += op;

        //Pad with ZEROs up to 8 digits
        string _highScoreStr = _highScore.ToString("D8");

        _highScoreObject.GetComponentInChildren<Text>().text = "HIGH SCORE: " + _highScoreStr;
    }
    #endregion HighScore
}
