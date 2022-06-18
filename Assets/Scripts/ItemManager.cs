using System.Collections;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Items item;

    WeaponController _weaponManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _weaponManager = FindObjectOfType<WeaponController>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<WeaponController>().inTrigger = true;
            if (Input.GetButton(KeyCode))
                StartCoroutine("wait");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
            other.GetComponent<WeaponController>().inTrigger = false;
    }

    IEnumerator wait()
    {
        if (_weaponManager.weaponType != "Null")
            _weaponManager.DropWeapon(_weaponManager.weaponType);
        yield return new WaitForSeconds(0.05f);
        _weaponManager.weaponType = item.weaponType.ToString();
        Destroy(gameObject);
    }
}
 
