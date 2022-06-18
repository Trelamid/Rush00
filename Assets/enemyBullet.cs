using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    private Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindWithTag("Player");
        dir = player.transform.position - transform.position;
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Player");
            // col.gameObject.GetComponent<>();
        }
        else if(col.gameObject.tag != "Enemy")
            Destroy(this.gameObject);
        // Debug.Log(col.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(dir.normalized* Time.deltaTime * 5);
        transform.position += transform.up * Time.deltaTime * 10;
    }
}
