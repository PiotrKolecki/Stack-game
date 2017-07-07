using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    float firstPressPos;
    float secondPressPos;
    public float forMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save begin of touch
            firstPressPos = Input.mousePosition.x;
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save end of touch
            secondPressPos = Input.mousePosition.x;
            //value of difference
            return secondPressPos - firstPressPos;
        }
        return 0f;
    }
    public float forTouch()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                firstPressPos = t.position.x;
            }
            if (t.phase == TouchPhase.Ended)
            {
                secondPressPos = t.position.x;
                return secondPressPos - firstPressPos;
            }
        }
        return 0f;
    }
}
