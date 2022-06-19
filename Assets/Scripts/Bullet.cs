using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        // transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0) * -1);
        Destroy(gameObject, 5f);        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            // Debug.Log(("shot on enemy"));
            col.gameObject.GetComponentInParent<EnemyController>().Death();
            Destroy(gameObject);
        }

        if (col.GetComponent<EnemyController>())
        {
            Debug.Log("Hit enemy");
            Destroy(gameObject);
        }
        if(col.tag != "Player" && col.tag != "Weapon" )
        {
            Debug.Log("Other object");
            Destroy(gameObject);
        }
    }
}
