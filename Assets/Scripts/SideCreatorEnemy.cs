using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCreatorEnemy : MonoBehaviour
{
    public List<GameObject> _Enemypoint = new List<GameObject>();
    [SerializeField] private GameObject _Enemy;
    [SerializeField] private bool _iscreat;
    public float _taraf;//sað taraftan gelen düþmanlar için -135 soldan 45 derece


    private float _delay;
    
    // Start is called before the first frame update
    void Start()
    {
        _iscreat = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_iscreat)
        {
            
            if (_delay <= Time.time)
            {
                _delay += 2;
                creator();
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("11");
            _iscreat = true;
            _delay = Time.time;






        }
    }

    private void creator()
    {
        

        for (int i = 0; i < _Enemypoint.Count; i++)
        {
            Instantiate(_Enemy, _Enemypoint[i].transform.position + new Vector3 (0,1,0), Quaternion.Euler(0,_taraf,0));

        }
            
        
    }
}
