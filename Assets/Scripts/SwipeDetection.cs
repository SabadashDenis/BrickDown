using System;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public static event OnSwipeInput SwipeEvent;
    public delegate void OnSwipeInput(Vector2 direction);

    public Vector2 tapPosition;

    public Vector2 swipeVector;

    public bool isSwiping;
    private bool isMobile;

    void Start()
    {
        isMobile = Application.isMobilePlatform;
    }

    void Update()
    {
        if (!isMobile)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isSwiping = true;
                tapPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                ResetSwipe();
            }
        }
        else
        {
            if(Input.touchCount > 0)
            {
                if(Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    isSwiping = true;
                    tapPosition = Input.GetTouch(0).position;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    ResetSwipe();
                }
            }
        }
        CheckSwipe();
    }

    private void CheckSwipe()
    {
        if (isSwiping)
        {
            if (!isMobile && Input.GetMouseButton(0))
                swipeVector = (Vector2)Input.mousePosition - tapPosition;
            else if (Input.touchCount > 0)
                swipeVector = Input.GetTouch(0).position - tapPosition;

            if (swipeVector.magnitude > 10)
            {
                if (SwipeEvent != null)
                {
                    if (Math.Abs(swipeVector.x) > Math.Abs(swipeVector.y))
                    {
                        SwipeEvent?.Invoke(swipeVector.y > 0 ? Vector2.right : Vector2.left);
                    }
                }
                ResetSwipe();
            }
        }
    }

    private void ResetSwipe()
    {
        isSwiping = false;
        tapPosition = Vector2.zero;
    }
}
