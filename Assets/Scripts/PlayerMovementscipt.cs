using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementscipt : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;

    private float _firsttouch;
    private float _swipeDiff;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._isgameactive)
        {
            MoveInputs();

        }
    }

    private void MoveInputs()
    {
        if (GameManager._isgameactive)
        {


            if (Input.touchCount > 0)
            {
                Touch _touch = Input.GetTouch(0);
                _firsttouch = _touch.position.x;
                if (_touch.deltaPosition.x < 0)
                {

                    transform.rotation = Quaternion.Euler(0, (_touch.deltaPosition.x - _firsttouch) / 10, 0);

                }
                if (_touch.deltaPosition.x > 0)
                {
                    transform.rotation = Quaternion.Euler(0, -(_touch.deltaPosition.x - _firsttouch) / 10, 0);

                }
                if (_touch.deltaPosition.x == 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }



            }
            else
                transform.rotation = Quaternion.Euler(0, 0, 0);

            /*if (Input.GetMouseButtonDown(0))
            {
                _firstFingerX = GetMousePos();
            }
            else if (Input.GetMouseButton(0))
            {
                _lastFingerX = GetMousePos();

                _swipeDiff = _lastFingerX - _firstFingerX;

                _firstFingerX = _lastFingerX;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _swipeDiff = 0;
                ResetLookRotation();
            }*/
        }
    }
}
