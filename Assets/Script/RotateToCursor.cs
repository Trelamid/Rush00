using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCursor : MonoBehaviour
{
    Vector3 mousePos;

    private Camera cam;
    
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        rotateToCursor();
    }

    void rotateToCursor()
    {
        mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);

        var auf = Quaternion.LookRotation((Vector2)mousePos - (Vector2)transform.position);
        Debug.Log(mousePos);
        Debug.Log(transform.position);
        auf.z = 0;
        auf.z = 0;
        transform.rotation = auf;

        /*var position = transform.position;
        Vector2 direction = new Vector2(
            mousePos.x - position.x,
            mousePos.y - position.y
        );
        transform.up = -direction;*/
    }
}
