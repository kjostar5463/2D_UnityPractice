using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    Vector2 cursorPos;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        cursorPos = Input.mousePosition;
        gameObject.transform.position = new Vector2(cursorPos.x / Screen.width * 18 - 9, cursorPos.y / Screen.height * 10 -5);
    }
    
}
