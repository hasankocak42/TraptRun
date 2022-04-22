using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    private bool _isroad = false;
    public float _road;
    [SerializeField] private int _taraf;
    
    private bool _run = true;
    private Animator _animator;
    [SerializeField] private float _speed;
    public GameObject _player;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("Run",true);
        if (transform.position.x<=0)
        {
            _taraf = 1;
            _road = Random.Range(0, 8);
        }
        else if (transform.position.x >= 8)
        {
            _taraf = 2;
        _road = Random.Range(0,8);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._isgameactive)
        {
        Move();

        }
    }

    private void Move()
    {
        if (_player.transform.position.z > transform.position.z)
        {
            _speed = 10f;
        }
        else
            _speed = 5.1f;



        if (_run)
        {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        }
        if (_road -1<= transform.position.x && transform.position.x <= _road)
        {
            
            if (_taraf==1)
            {
                transform.rotation = Quaternion.Euler(0,0,0); ;
                _taraf = 3;

            }
            else if (_taraf ==2)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                _taraf = 3;
            }
        }
        
        



    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.LookAt(collision.transform.position);
            _run = false;
            _animator.SetTrigger("Jump");
            
        }
    }

}
