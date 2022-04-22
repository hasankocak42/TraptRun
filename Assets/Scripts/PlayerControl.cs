using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerControl : MonoBehaviour
{
    public Material _cubematerial;
    private Animator _animator;
    private Rigidbody _rigi;
    private bool _run;
    public Transform _helicopter;
    [SerializeField] private bool _isjump;
    public GameManager _gamemanager;
    private bool gameactive = true;

    

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
        _animator.SetBool("Run", _run);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y<=-10)
        {
            GameManager._isgameactive = false;
            _gamemanager._canvasgameover.SetActive(true);
        }

        if (_isjump)
        {
            Jumping();
        }

        if (Input.touchCount > 0 && gameactive)
        {
            _gamemanager.StartGame();
            gameactive = false;
        }

        if (GameManager._isgameactive)
        {
            

            if (_run)
            {
                transform.Translate(Vector3.forward * 5f * Time.deltaTime);

            }
           
            

            
        }
    }

    private void Jumping()
    {
        transform.DOMove(_helicopter.position,2f);
          /*  Debug.Log("jump");
            // The center of the arc
            Vector3 center = (transform.position + _helicopter.position) * 0.5f;

            // move the center a bit downwards to make the arc vertical
            center -= new Vector3(0, 9, 0);

            // Interpolate over the arc relative to center
            Vector3 riseRelCenter = transform.position - center;
            Vector3 setRelCenter = _helicopter.position - center;

            // The fraction of the animation that has happened so far is
            // equal to the elapsed time divided by the desired time for
            // the total journey.


            transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, 0.05f);
            transform.position += center;*/

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("enemy")&&GameManager._isgameactive)
        {
            _run = false;

            GameManager._isgameactive = false;
            _gamemanager._canvasgameover.SetActive(true);
           
            _animator.SetTrigger("Fall");
           


        }
        if (collision.gameObject.CompareTag("Finish") && GameManager._isgameactive)
        {
            _gamemanager._canvaswin.SetActive(true);
            GameManager._isgameactive = false;
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
