using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Material _cubematerial;
    private Animator _animator;
    private Rigidbody _rigi;
    private bool _run;
    public Transform _helicopter;
    private bool _isjump;


    

    // Time to move from sunrise to sunset position, in seconds.
    

    // The time at which the animation started.
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        _run = true;
        _isjump = false;
        _animator = GetComponent<Animator>();
        _rigi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_run)
        {
            transform.Translate(Vector3.forward * 5f * Time.deltaTime);

        }
        if (_isjump)
        {
            // The center of the arc
            Vector3 center = (transform.position + _helicopter.position) ;

            // move the center a bit downwards to make the arc vertical
            center -= new Vector3(0, 10 , 0);

            // Interpolate over the arc relative to center
            Vector3 riseRelCenter = transform.position - center;
            Vector3 setRelCenter = _helicopter.position - center;

            // The fraction of the animation that has happened so far is
            // equal to the elapsed time divided by the desired time for
            // the total journey.


            transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, 0.05f) ;
            transform.position += center;
        }

        _animator.SetBool("Run", _run);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("enemy"))
        {
            _run = false;

            GameManager._isgameactive = false;
            _animator.SetTrigger("Fall");


        }




    }
    private void OnCollisionExit(Collision collision)
    {
        if (GameManager._isgameactive)
        {

            if (collision.gameObject.CompareTag("end"))
            {
                _run = false;
                Debug.Log("finish");
                GameManager._isgameactive = false;
                _animator.SetTrigger("Jump");
                _isjump = true;
            }



            if (collision.gameObject.CompareTag("cube"))
            {
                //collision.gameObject.isStatic = false;
                collision.gameObject.GetComponent<Renderer>().material = _cubematerial;
                for (int i = 0; i < collision.gameObject.GetComponentsInChildren<Renderer>().Length; i++)
                {

                    collision.gameObject.GetComponentsInChildren<Renderer>()[i].material = _cubematerial;
                }
                // collision.gameObject.GetComponentInChildren<Renderer>().material = _cubematerial;
                collision.gameObject.GetComponent<Collider>().enabled = false;
                collision.gameObject.AddComponent<Rigidbody>();
                collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * 5 * Time.deltaTime);

                Destroy(collision.gameObject, 5f);
            }
            
            



        }

    }

    private void Jumpslerp()
    {

        transform.position = Vector3.Lerp(transform.position, _helicopter.transform.position, 2f);
    }



}
