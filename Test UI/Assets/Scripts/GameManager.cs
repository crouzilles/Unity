using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LetterHolder _letterHolder;
    [SerializeField] private WordHolder _wordHolder;

    private void Start()
    {
        Application.targetFrameRate = 60;
        //Reset();
    }

    public void Reset()
    {
        FindObjectOfType<LetterHolder>().Reset();
        FindObjectOfType<WordHolder>().Reset();
        FindObjectOfType<ScoreManager>().ResetTries();
    }
}
