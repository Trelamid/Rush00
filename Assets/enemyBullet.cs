using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    private Vector2 dir;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindWithTag("Player");
        dir = player.transform.position - transform.position;
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject);
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Player");
            col.gameObject.GetComponentInParent<PlayerWeaponManager>().enabled = false;
            col.gameObject.GetComponentInParent<PlayerMove>().enabled = false;
            col.gameObject.GetComponentInParent<RotatePlayer>().enabled = false;
            col.gameObject.GetComponentInParent<PlayerWeaponManager>().death = true;
        }
        if(col.gameObject.tag != "Enemy" && col.gameObject.tag != "Weapon" )
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Player");
            col.gameObject.GetComponentInParent<PlayerWeaponManager>().enabled = false;
            col.gameObject.GetComponentInParent<PlayerMove>().enabled = false;
            col.gameObject.GetComponentInParent<RotatePlayer>().enabled = false;
            col.gameObject.GetComponentInParent<PlayerWeaponManager>().death = true;
        }
        if(col.gameObject.tag != "Enemy"  && col.gameObject.tag != "Weapon" )
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(dir.normalized* Time.deltaTime * 5);
        transform.position += transform.up * Time.deltaTime * speed;
    }
}
