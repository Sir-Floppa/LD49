using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{

    #region GesturesManagement
    [Header("Tweaks")]
    [SerializeField] Vector2 deadzone;
    [SerializeField] float doubleTapDelta = 0.5f;
    [SerializeField] float longTapDelta = 0.5f;

    [Header("Logic")]
    public bool BeginTap;
    public bool Tap;
    public bool EndTap;
    public bool doubleTap;
    public bool swipeLeft;
    public bool swipeRight;
    public bool swipeUp;
    public bool SwipeDown;
    public Vector2 swipeDelta;
    Vector2 startTouch;
    float lastTap;
    float sqrDeadzone;
    public bool isTap = false;
    public bool Touching = false;
    public Vector2 Touchlocal;
    public bool longTap;

    public bool Sliding;


    Vector2 ScreentoScale;

    public Vector2 taplocal;

    #endregion


    void UpdateStandalone()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BeginTap = true;
            isTap = true;
            startTouch = Input.mousePosition;
            doubleTap = Time.time - lastTap < doubleTapDelta;
            lastTap = Time.time;
            taplocal = startTouch;
            Touching = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startTouch = swipeDelta = Vector2.zero;
            Touching = false;
            EndTap = true;
            if (isTap)
            {
                Tap = true;
                isTap = false;
            }
        }

        //Reset distance, get the new swipeDelta
        swipeDelta = Vector2.zero;

        if (Touching)
        {
            Touchlocal = Input.mousePosition;
        }

        if (Touching && Time.time - lastTap > longTapDelta && isTap)
        {
            longTap = true;
            isTap = false;
        }

        if (startTouch != Vector2.zero && Touching)
            swipeDelta = (Vector2)Input.mousePosition - startTouch;

        if (Mathf.Abs(swipeDelta.x) > deadzone.x)
        {
            isTap = false;

            if (swipeDelta.x < 0)
                swipeLeft = true;
            else
                swipeRight = true;

            startTouch = new Vector2(Input.mousePosition.x, startTouch.y);
        }
        if (Mathf.Abs(swipeDelta.y) > deadzone.y)
        {
            isTap = false;

            if (swipeDelta.y < 0)
                SwipeDown = true;
            else
                swipeUp = true;
        }

        //if (swipeDelta.sqrMagnitude > sqrDeadzone)
        //{

        //    isTap = false;

        //    float x = swipeDelta.x;
        //    float y = swipeDelta.y;

        //    if (Mathf.Abs(x) > Mathf.Abs(y))
        //    {

        //    }
        //    else
        //    {

        //    }
        //    startTouch = swipeDelta = Vector2.zero;
        //}
    }

    void UpdateMobile()
    {

        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                BeginTap = true;
                isTap = true;
                startTouch = Input.mousePosition;
                doubleTap = Time.time - lastTap < doubleTapDelta;
                lastTap = Time.time;
                taplocal = startTouch;
                Touching = true;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                startTouch = swipeDelta = Vector2.zero;
                Touching = false;
                EndTap = true;
                if (isTap)
                {
                    Tap = true;
                    isTap = false;
                }
            }

            //Reset distance, get the new swipeDelta
            swipeDelta = Vector2.zero;

            if (Touching)
            {
                Touchlocal = Input.mousePosition;
            }

            if (Touching && Time.time - lastTap > longTapDelta && isTap)
            {
                longTap = true;
                isTap = false;
            }

            if (startTouch != Vector2.zero && Touching)
                swipeDelta = (Vector2)Input.mousePosition - startTouch;

            if (Mathf.Abs(swipeDelta.x) > deadzone.x)
            {
                isTap = false;

                if (swipeDelta.x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;

                startTouch = new Vector2(Input.mousePosition.x, startTouch.y);
            }
            if (Mathf.Abs(swipeDelta.y) > deadzone.y)
            {
                isTap = false;

                if (swipeDelta.y < 0)
                    SwipeDown = true;
                else
                    swipeUp = true;
            }
        }
    }


    void GesturesExecutrion()
    {
        //Reset Bools
        BeginTap = Tap = EndTap = doubleTap = swipeLeft = swipeRight = swipeUp = SwipeDown = longTap = false;

        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            UpdateStandalone();
        }
        else
        {
            UpdateMobile();
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GesturesExecutrion();
    }
}
