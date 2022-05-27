using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkOverlay : MonoBehaviour
{
    private float _speed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeTo(0.0f, _speed));
    }
    IEnumerator FadeTo(float aValue, float speed)
    {
        Color color = GetComponent<Image>().color;
        float alpha = color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / speed)
        {
            Color newColor = new Color(color.r, color.g, color.b, Mathf.Lerp(alpha, aValue, t));
            GetComponent<Image>().color = newColor;
            yield return null;
        }
        FindObjectOfType<WordHolder>().Reset();
        Destroy(this.gameObject);
    }
}
