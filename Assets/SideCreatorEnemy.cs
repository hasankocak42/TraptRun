using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCreatorEnemy : MonoBehaviour
{
    public List<GameObject> _Enemypoint = new List<GameObject>();
    [SerializeField] private GameObject _Enemy;

    private float _delay;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            for (int i = 0; i < _Enemypoint.Count; i++)
            {
                   Instantiate(_Enemy,_Enemypoint[i].transform.position,transform.rotation);

            }
            

                    
                
                
            
        }
    }
}
