using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Image _img;
    private Text _txt;
    private Color32 _originalColor;
    private Color32 _originalTextColor;
    private bool _over = false;

    void Awake()
    {
        _img = GetComponent<Image>();
        _txt = GetComponentInChildren<Text>();
        _originalColor = _img.color;
        _originalTextColor = _txt.color;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _img.color = new Color32(196, 129, 29, 255);
        _txt.color = _originalTextColor;
        _over = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _img.color = _originalColor;
        _txt.color = _originalTextColor;
        _over = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _img.color = new Color32(196, 65, 39, 255);
        _txt.color = new Color32(226, 208, 0, 255);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_over)
        {
            _img.color = new Color32(196, 129, 29, 255);
            _txt.color = _originalTextColor;
        }
        else
        {
            _img.color = _originalColor;
            _txt.color = _originalTextColor;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        FindObjectOfType<GameManager>().Reset();
    }
}
