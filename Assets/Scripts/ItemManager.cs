using System.Collections;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Items item;
    public Sprite weaponImg = null;
    PlayerWeaponManager _weaponManager;

    // Start is called before the first frame update
    void Start()
    {
        _weaponManager = FindObjectOfType<PlayerWeaponManager>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.name == "Player")
        {
            other.GetComponent<PlayerWeaponManager>().trigger = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine("wait");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
            other.GetComponent<PlayerWeaponManager>().trigger = false;
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
