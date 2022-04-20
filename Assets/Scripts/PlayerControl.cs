using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Material _cubematerial;
    private Animator _animator;
    private Rigidbody _rigi;
    private bool _run;

    // Start is called before the first frame update
    void Start()
    {
        _run = true;

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

        _animator.SetBool("Run", _run);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (GameManager._isgameactive)
        {




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
            if (collision.gameObject.CompareTag("enemy"))
            {
                _run = false;
               
                GameManager._isgameactive = false;
                _animator.SetTrigger("Fall");


            }
            if (collision.gameObject.CompareTag("Finish"))
            {
                _run = false;

                GameManager._isgameactive = false;
                _animator.SetTrigger("Jump");
            }
        }
    }



}
