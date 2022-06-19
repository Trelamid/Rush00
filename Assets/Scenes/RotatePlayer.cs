using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    private Camera _camera;
    private GameObject _a;
    public float offset = 0;
    // Start is called before the first frame update
    void Start()
    {
        _a = transform.GetChild(0).gameObject;
        _camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseDir = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float Z = Mathf.Atan2(mouseDir.y , mouseDir.x) * Mathf.Rad2Deg;
        
        _a.transform.rotation = Quaternion.Euler(0,0, Z + offset);

    }
}
