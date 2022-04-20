using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    private bool _isroad = false;
    public float _road;
    private int _taraf;
    private Transform a;
    private bool _run = true;
    private Animator _animator;
    
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
        if (transform.position.x >= 8)
        {
            _taraf = 2;
        _road = Random.Range(0,8);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
    }

    private void Move()
    {
        if (_run)
        {
        transform.Translate(Vector3.forward * 6f * Time.deltaTime);

        }
        if (_road -1<= transform.position.x && transform.position.x <= _road)
        {
            
            if (_taraf==1)
            {
            transform.Rotate(new Vector3(0f, -135f, 0f));
                _taraf = 3;

            }
            if (_taraf ==2)
            {
            transform.Rotate(new Vector3(0f, 135f, 0f));
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
