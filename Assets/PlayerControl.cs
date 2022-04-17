using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Material _cubematerial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 5f * Time.deltaTime);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("cube"))
        {
            //collision.gameObject.isStatic = false;
            collision.gameObject.GetComponent<Renderer>().material = _cubematerial;
            collision.gameObject.GetComponent<Collider>().enabled = false;
            collision.gameObject.AddComponent<Rigidbody>();
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down* 5*Time.deltaTime);
            
            Destroy(collision.gameObject, 5f);
        }
    }
    


}
