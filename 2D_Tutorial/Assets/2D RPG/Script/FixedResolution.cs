using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedResolution : MonoBehaviour
{
    private void Awake()
    {
        Rect rect = Camera.main.rect;

        float height = ((float)Screen.width / Screen.height) / (9.0f / 19.0f);
        float width = 1f / height;

        if(height < 1f)
        {
            rect.height = height;
            rect.y = (1f - width) / 2f;
        }
        else
        {
            rect.width = width;
            rect.x = (1f - width) / 2f;
        }

        Camera.main.rect = rect;
    }

    public void OnPreCull()
    {
        GL.Clear(true, true, Color.black);
    }

}
