using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public enum Bounds { LeftRight, TopBottom, All };
    public Bounds bounds;
    public SpriteRenderer gameBoundsSprite;

    private float orthoSize;


    // Start is called before the first frame update
    void Start()
    {
        DefineBounds();
    }

    private void OnPreRender()
    {
        DefineBounds();
    }

    void DefineBounds()
    {
        if (bounds.ToString() == "LeftRight")
            LeftRight();
        if (bounds.ToString() == "TopBottom")
            TopBottom();
        if (bounds.ToString() == "All")
            All();

        Camera.main.orthographicSize = orthoSize;
    }

    void LeftRight()
    {
        this.orthoSize = gameBoundsSprite.bounds.size.x * Screen.height / Screen.width * 0.5f;
    }

    void TopBottom()
    {
        this.orthoSize = gameBoundsSprite.bounds.size.y / 2;
    }

    void All()
    {
        //Calculate screen ratio
        float screenRatio = (float)Screen.width / (float)Screen.height;
        //Calculate target sprite ratio
        float targetRatio = gameBoundsSprite.bounds.size.x / gameBoundsSprite.bounds.size.y;

        if (screenRatio >= targetRatio)
            this.orthoSize = gameBoundsSprite.bounds.size.y / 2;
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            this.orthoSize = gameBoundsSprite.bounds.size.y / 2 * differenceInSize;
        }
    }
}
