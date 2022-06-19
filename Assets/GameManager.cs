using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject _player;
    private PlayerWeaponManager _characterController;
    private float _time;

    public GameObject winImpact;
    public GameObject loseImpact;

    private bool deathh;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _characterController = _player.GetComponent<PlayerWeaponManager>();
    }

    void Update()
    {
        if (_characterController.death && !deathh)
        {
            deathh = true;
            Instantiate(loseImpact);
            Debug.Log("You lose!");
            // Invoke("GoMainMenu", 3);
        }

        if (Time.time > _time && !deathh)
        {
            _time = Time.time + 1;
            var enemy = GameObject.FindWithTag("Enemy");
            if (!enemy)
            {
                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    Instantiate(winImpact);
                    Debug.Log("You win!");
                    // Invoke("GoMainMenu", 3);
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }

            }
        }
    }

    void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
