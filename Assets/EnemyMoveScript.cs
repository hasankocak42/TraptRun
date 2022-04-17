using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    private bool _isroad = false;
    public float _road;
    private int _taraf;
    private Transform a;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x<=-3)
        {
            _taraf = 1;
        }
        if (transform.position.x >= 19)
        {
            _taraf = 2;
        }
        
        _road = Random.Range(2,17);
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        transform.Translate(Vector3.forward * 6f * Time.deltaTime);
    }

    private void Move()
    {
        if (_road -1<= transform.position.x && transform.position.x <= _road)
        {
            Debug.Log("1");
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

}
