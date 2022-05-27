using System.IO;
using System.Linq;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    private string _wordFilePath, _wordFile, _scoreFile, _scoreFilePath = null;

    public string GetWord()
    {
        if (_wordFile == null)
            GetWordFile();

        int lineCount = File.ReadLines(this._wordFilePath).Count<string>();
        int lineNumber = Random.Range(2, lineCount);
        string word = File.ReadLines(this._wordFilePath).Skip<string>(lineNumber).Take<string>(1).First<string>();
        return word.ToUpper();

    }

    public string GetHighScore()
    {
        Debug.Log("in GetHighScore");
        if (_scoreFile == null)
            GetHighScoreFile();
        return File.ReadLines(this._scoreFilePath).Take<string>(1).First<string>();
    }

    private void GetWordFile()
    {
        _wordFile = "words.txt";
        _wordFilePath = Application.dataPath + "/" + _wordFile;
    }

    private void GetHighScoreFile()
    {
        Debug.Log("In GetHighScoreFile");
        _scoreFile = "score.txt";
        _scoreFilePath = Application.dataPath + "/" + _scoreFile;
        Debug.Log(_scoreFilePath);
        if (!File.Exists(_scoreFilePath))
            File.WriteAllText(_scoreFilePath, "0");
    }
}
