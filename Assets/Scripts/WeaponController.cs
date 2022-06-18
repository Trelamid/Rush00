using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // public float speed = 10f;
    public bool isUnlimited = false;
    public string weaponType;
    public bool inTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WeaponManager();
    }
    
    void WeaponManager()
    {
        if (Input.GetMouseButtonDown(1) && !inTrigger)
        {
            DropWeapon(weaponType);
        }
    }

    public void DropWeapon(string weapon)
    {
        if (weaponType != "Null")
        {
            Instantiate(Resources.Load("Prefabs/" + weapon), transform.position, Quaternion.identity);
            if (!inTrigger)
                weaponType = "Null";
        }
        else
        {
            Debug.Log("weapon is null");
        }
        
    }
}
