using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cold : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<EnemyController>())
        {
            Destroy(gameObject);
        }
        if(col.tag == "other")
        {
            Destroy(gameObject);
        }
    }
}
