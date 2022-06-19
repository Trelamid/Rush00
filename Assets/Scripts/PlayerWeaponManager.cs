using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public string weaponType;
    public bool trigger = false, shoot = true;
    public GameObject spawn;
    private float _rateOfFire;
    public bool death;

    public float RateOfFire
    {
        get => _rateOfFire;
        set => _rateOfFire = value;
    }

    private float _nextFire;

    public GameObject weaponImg = null;
    // Start is called before the first frame update
    private void Start()
    {
        _nextFire = 0;
    }

    void Update()
    {
        WeaponManager();
        AttackManager(weaponType);
        switch (weaponType)
        {
            case "Uzi":
                RateOfFire = 0.1f;
                break;
            case "Shotgun":
                RateOfFire = 1.0f;
                break;
            case "Saber":
                RateOfFire = 0.3f;
                break;
            case "RocketLauncher":
                RateOfFire = 0.9f;
                break;
            case "Magnum":
                RateOfFire = 0.5f;
                break;
            case "Cricket":
                RateOfFire = 0.8f;
                break;
            case "MachineGun":
                Debug.Log(weaponType);
                RateOfFire = 0.3f;
                break;
        }
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
            // Debug.Log(Resources.Load("Prefabs/" + weapon));
            Instantiate(Resources.Load("Prefabs/" + weapon), transform.position, Quaternion.identity);
            if (!trigger)
                weaponType = "Null";
        }
        else
            Debug.Log("weapon is null");  
    }

    void AttackManager(string weaponType)
    {
        if (Time.time > _nextFire)
        {
            _nextFire = Time.time + _rateOfFire;
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Instantiate(Resources.Load("Prefabs/" + weaponType + "_bullet"), spawn.transform.position, spawn.transform.rotation);
            }
        }
    }

    public void ColdWeapon()
    {
        StartCoroutine("waitHand", 0.2f);
    }


    IEnumerator shooting(float t)
    {
        Debug.Log("~~~~~~~~~~shoot");
        Instantiate(Resources.Load("Prefabs/" + weaponType + "_bullet"), spawn.transform.position, spawn.transform.rotation);
        yield return new WaitForSeconds(t);
        if (spawn.GetComponent<BoxCollider2D>() != null)
            spawn.GetComponent<BoxCollider2D>().enabled = false;
    }
    
    IEnumerator waitHand(float t)
    {
        spawn.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(t);
        spawn.GetComponent<BoxCollider2D>().enabled = false;
    }
}
