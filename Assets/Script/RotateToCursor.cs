using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCursor : MonoBehaviour
{
    Vector3 mousePos;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateToCursor();
    }

    void rotateToCursor()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        var position = transform.position;
        Vector2 direction = new Vector2(
            mousePos.x - position.x,
            mousePos.y - position.y
        );
        transform.up = -direction;
    }
}
