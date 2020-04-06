using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeScript : MonoBehaviour
{
    public GameObject JokerScript;
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDragging = false;
    private Vector2 startTouch, swipeDelta;

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool SwipeUp { get { return swipeUp; } }



    // Update is called once per frame
    void Update()
    {
        tap = swipeLeft = swipeRight = swipeDown = swipeUp = false;

        //touching
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;

            }else if(Input.touches[0].phase==TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                Reset();
            }
        }

        //calculating
        swipeDelta = Vector2.zero;
        if (isDragging)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }
        int swipeController = JokerScript.GetComponent<JokerScript>().swipeController;
        //crossDeadZone
        if (swipeDelta.magnitude > 125)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if(Mathf.Abs(x)> Mathf.Abs(y))
            {
                if (x < 0 && swipeController == 1)
                {
                    swipeLeft = true;
                }
                else if( swipeController == 1)
                {
                    swipeRight = true;
                }


            }
            else
            {
                if (y < 0 && swipeController == 1)
                {
                    swipeDown = true;
                }
                else if(swipeController == 1)
                {
                    swipeUp = true;
                }
            }


            Reset();
        }
    }
    private void Reset()
    {
        startTouch =swipeDelta= Vector2.zero;
        isDragging = false;
    }
}
