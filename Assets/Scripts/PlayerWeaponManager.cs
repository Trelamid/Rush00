using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public string weaponType;
    public bool trigger = false, shoot;
    public Transform spawn;

    public GameObject weaponImg = null;
    // Start is called before the first frame update
    void Update()
    {
        WeaponManager();
        AttackManager(weaponType);
    }
    
    void WeaponManager()
    {
        if (Input.GetMouseButtonDown(1))
        {
            DropWeapon(weaponType);
        }
    }
    
    public void DropWeapon(string weapon)
    {
        if (weaponType != "Null")
        {
            Debug.Log(Resources.Load("Prefabs/" + weapon));
            Instantiate(Resources.Load("Prefabs/" + weapon), transform.position, Quaternion.identity);
            if (!trigger)
                weaponType = "Null";
        }
        else
        {
            Debug.Log("weapon is null");
        }
        
    }

    void AttackManager(string weaponType)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(weaponType);
            switch (weaponType)
            {
                case "Null":
                    break;
                case "Uzi":
                    if (shoot)
                        StartCoroutine("shooting", 0.7f);
                    break;
                case "Shotgun":
                    if (shoot)
                        StartCoroutine("shooting", 1f);
                    break;
                case "Saber":
                    if (shoot)
                        StartCoroutine("shooting", 2f);
                    break;
                case "RocketLauncher":
                    if (shoot)
                        StartCoroutine("shooting", 1.7f);
                    break;
                case "Magnum":
                    if (shoot)
                        StartCoroutine("shooting", 2.7f);
                    break;
                case "Cricket":
                    if (shoot)
                        StartCoroutine("shooting", 3.7f);
                    break;
                case "MachineGun":
                    if (shoot)
                        StartCoroutine("shooting", 1.7f);
                    break;
                default:
                    break;
            }
        }
    }

    public void ColdWeapon()
    {
        StartCoroutine("waitHand", 0.2f);
    }
    IEnumerator shooting(float t)
    {
        Instantiate(Resources.Load("Prefabs/" + weaponType + "_bullet"), spawn.position, spawn.rotation);
        yield return new WaitForSeconds(t);
        spawn.GetComponent<BoxCollider2D>().enabled = false;
    }
    
    IEnumerator waitHand(float t)
    {
        spawn.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(t);
        spawn.GetComponent<BoxCollider2D>().enabled = false;
    }
}
