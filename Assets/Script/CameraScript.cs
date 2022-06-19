using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform player;
    void Start()
    {
        player = FindObjectOfType<PlayerMove>().transform;
    }

    
    void Update()
    {
        var position = player.position;
        transform.position = new Vector3(position.x, position.y, -10);
    }
}
