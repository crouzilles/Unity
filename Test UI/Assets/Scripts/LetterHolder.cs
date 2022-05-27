using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterHolder : MonoBehaviour
{
    [SerializeField] private ClickableLetter _letter;
    private int _numLetters = 26;
    private char _firstLetter = 'A';

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        ClearLetters();
        InitLetterHolder(_letter.gameObject, 26, 'A', this.transform);
    }

    private void ClearLetters()
    {
        foreach (ClickableLetter obj in FindObjectsOfType<ClickableLetter>())
        {
            Destroy(obj.gameObject);
        }
    }

    public GameObject[] InitLetterHolder(GameObject letter, int numLetters, char startLetter, Transform parent)
    {
        GameObject[] _letters = new GameObject[numLetters];

        for (int i = 0; i < numLetters; i++)
        {
            var obj = Instantiate(letter, parent);

            char c = (char)(startLetter + i);
            string ltr = c.ToString();

            obj.GetComponent<TMP_Text>().text = ltr;
            obj.GetComponent<TMP_Text>().outlineColor = Color.black;
            obj.GetComponent<TMP_Text>().outlineWidth = 0.15f;
            obj.name = "L_" + letter;

            _letters[i] = obj.gameObject;
        }

        return _letters;
    }
}
