using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cold : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.gameObject.GetComponentInParent<EnemyController>().Death();
            Destroy(gameObject);
        }
        if(col.tag == "other")
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, 0.1f);
    }
}
