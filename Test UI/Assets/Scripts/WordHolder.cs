using System.Collections;
using System;
using TMPro;
using UnityEngine;

public class WordHolder : MonoBehaviour
{
    [SerializeField] private GameObject _letter;
    [SerializeField] private Color _letterColor;
    [SerializeField] private FileManager fm;

    private GameObject[] _letters;
    public string _currentWord;

    // Start is called before the first frame update
    void Start()
    {
        ClearLetters();
    }

    public void Reset()
    {
        ClearLetters();
        _currentWord = fm.GetWord();
        InitWordHolder(_letter, this.transform, _currentWord);
    }

    private void ClearLetters()
    {
        foreach (LargeLetter obj in FindObjectsOfType<LargeLetter>())
        {
            Destroy(obj.gameObject);
        }
    }

    private void InitWordHolder(GameObject letter, Transform parent, string word)
    {
        _letters = new GameObject[word.Length];

        for (int i = 0; i < word.Length; i++)
        {
            var obj = Instantiate(letter, parent);
            var txt = obj.GetComponent<TMP_Text>();

            txt.text = "_";
            txt.margin = new Vector4(0, 0, 0, 35);
            txt.outlineColor = Color.black;
            txt.outlineWidth = 0.15f;
            obj.name = "W_" + word[i].ToString();

            _letters[i] = obj.gameObject;
        }
    }

    public bool CheckWord(char letter)
    {
        bool found = false;
        for (int i = 0; i < _currentWord.Length; i++)
        {
            if (_currentWord[i] == letter)
            {
                UpdateWord(i, letter);
                found = true;
            }
        }
        return found;
    }

    public void UpdateWord(int pos, char letter)
    {
        _letters[pos].GetComponent<TMP_Text>().text = letter.ToString();
        _letters[pos].GetComponent<TMP_Text>().margin = new Vector4(0, 0, 0, 0);
    }
}
