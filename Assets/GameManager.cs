using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject _player;
    private CharacterController _characterController;
    private float _time;

    public GameObject winImpact;
    public GameObject loseImpact;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _characterController = _player.GetComponent<CharacterController>();
    }

    void Update()
    {
        // if (_characterController.death)
        // {
        //     Instantiate(loseImpact);
        //     Debug.Log("You lose!");
        //     // Invoke("GoMainMenu", 3);
        // }

        if (Time.time > _time)
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
