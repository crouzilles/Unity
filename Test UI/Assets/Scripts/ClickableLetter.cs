using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ClickableLetter : MonoBehaviour, IPointerClickHandler
{
    private bool _isClickable = true;
    private TMP_Text txt;
    public void OnPointerClick(PointerEventData eventData)
    {

        if (_isClickable)
        {
            if (FindObjectOfType<WordHolder>().CheckWord(txt.text[0]))
                txt.color = Color.green;
            else
            {
                txt.color = Color.red;
                FindObjectOfType<ScoreManager>().DisplayTries(-1);
            }

            _isClickable = false;
        }
    }
    void Start()
    {
        txt = GetComponent<TMP_Text>();
    }
}
