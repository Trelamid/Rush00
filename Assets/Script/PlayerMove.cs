 using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3f;

    public Rigidbody2D rb;

    private Vector2 movement;

    private Camera cam;

    Vector3 mousePos;

    private NavMeshAgent _navMeshAgent;
    
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }
    
    void FixedUpdate()
    {
        // _navMeshAgent.Move(movement * moveSpeed * Time.fixedDeltaTime);
        Debug.Log("fds");
        //_navMeshAgent.Move(movement * moveSpeed * Time.fixedDeltaTime);
        RotationCharacter();
        transform.Translate(new Vector3(movement.x, 0, movement.y) * moveSpeed);
    }
    
    void RotationCharacter()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            Input.mousePosition.z - cam.transform.position.z));
        /*rb.transform.eulerAngles = new Vector3(0, 0,
            Mathf.Atan2((mousePos.y - transform.position.y), (mousePos.x - transform.position.x)) * Mathf.Rad2Deg);*/
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Door")
            _navMeshAgent.isStopped = true;
    }
}
