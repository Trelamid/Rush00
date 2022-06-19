using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public enum type
    {
        simple, robot, turell
    }

    public type _type;
    private NavMeshAgent _navMeshAgent;
    private GameObject _player;
    private bool _attack;
    private float _time;

    public float _distVisionForward;
    public float _distVisionBack;
    public float _distVisionShoot = 5;
    // public int damage;
    // public float bulletSpeed;

    public float rateOfFire;
    public GameObject bullet;
    public GameObject weapon;
    
    public bool patrul;
    public Vector2[] points;
    private int destNow = 0;
    
    
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindWithTag("Player");
        if(patrul)
            _navMeshAgent.SetDestination(points[destNow]);
    }

    void Update()
    {
        if (_attack)
            AttackAndMove();
        else if(patrul)
            Patrul();
        
        CheckVision();
    }

    void Patrul()
    {
        if ((points[destNow] - (Vector2) transform.position).magnitude < 1)
        {
            if (destNow < points.Length)
                destNow++;
            else
                destNow = 0;

            _navMeshAgent.SetDestination(points[destNow]);
        }
    }
    
    void AttackAndMove()
    {
        _navMeshAgent.SetDestination(_player.transform.position - (_player.transform.position - transform.position).normalized * 1);

        if (Time.time > _time)
        {
            _time = Time.time + rateOfFire;
            if (_type == type.simple)
            {
                var Bullet = Instantiate(bullet, weapon.transform.position,
                    Quaternion.LookRotation((Vector2) _player.transform.position - (Vector2) transform.position));
                Bullet.transform.rotation = new Quaternion(0, 0,
                    transform.rotation.z, transform.rotation.w);
            }
            else if (_type == type.robot)
            {
                var Bullet1 = Instantiate(bullet, weapon.transform.position + -transform.right,
                    Quaternion.LookRotation((Vector2) _player.transform.position - (Vector2) transform.position));
                Bullet1.transform.rotation = new Quaternion(0, 0,
                    transform.rotation.z, transform.rotation.w);
                
                var Bullet2 = Instantiate(bullet, weapon.transform.position +transform.right,
                    Quaternion.LookRotation((Vector2) _player.transform.position - (Vector2) transform.position));
                Bullet2.transform.rotation = new Quaternion(0, 0,
                    transform.rotation.z, transform.rotation.w);
            }
        }
    }

    void CheckVision()
    {
        Vector2 enemyPos = transform.position;
        Vector2 playerPos = _player.transform.position;
        float dist = (playerPos - enemyPos).magnitude;
        
        // if (CharacterController.shoot && !_attack && dist < _distVisionShoot)
        // {
        //     _attack = true;
        // }
        
        float pos = Quaternion.LookRotation(_player.transform.position - transform.position).z;

        RaycastHit2D raycastHit2D;
        Ray2D ray;
        // ray = new Ray2D(transform.position, playerPos - enemyPos);
        raycastHit2D = Physics2D.Raycast(transform.position, playerPos - enemyPos, 10000, 1 << 0);
        if (raycastHit2D && raycastHit2D.collider.gameObject.tag == "Player")
        {
            // if(raycastHit2D.collider.gameObject.tag != "Player")
            //     return;
        }
        else
        {
            Debug.Log(raycastHit2D.collider.name);
            return;
        }
  
        if (!_attack && pos < 0 && dist < _distVisionForward)
        {
            // Debug.Log("forward");
            // Debug.Log(pos);
            _attack = true;
        }
        else if (!_attack && pos >= 0 && dist < _distVisionBack)
        {
            // Debug.Log(pos);
            // Debug.Log("back");
            _attack = true;
        }
    }
}
