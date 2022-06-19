using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public string weaponType;
    public bool trigger = false;
    // Start is called before the first frame update
    void Update()
    {
        WeaponManager();
    }
    
    void WeaponManager()
    {
        if (Input.GetMouseButtonDown(1) && !trigger)
        {
            DropWeapon(weaponType);
        }
    }

    public void DropWeapon(string weapon)
    {
        if (weaponType != "Null")
        {
            Instantiate(Resources.Load("Prefabs/" + weapon), transform.position, Quaternion.identity);
            if (!trigger)
                weaponType = "Null";
        }
        else
        {
            Debug.Log("weapon is null");
        }
        
    }
}
