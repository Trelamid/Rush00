using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, speed * Time.deltaTime));
        Destroy(gameObject, 5f);        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<EnemyController>())
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
        if(col.tag == "other")
        {
            Debug.Log("Other");
            Destroy(gameObject);
        }
    }
}
