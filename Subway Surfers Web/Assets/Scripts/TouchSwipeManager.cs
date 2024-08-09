using UnityEngine;

public class TouchSwipeManager : MonoBehaviour
{
    private Player_move _player;// Assign in the inspector

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private float swipeThreshold = 50f; // Minimum distance in pixels for a swipe

    private void Awake()
    {
        try
        {
            _player = GameObject.FindWithTag("Player").GetComponent<Player_move>();
        }
        catch (System.Exception e) 
        {
            Debug.LogError(e);
        }
        
    }
    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    endTouchPosition = touch.position;
                    HandleSwipe();
                    break;
            }
        }
    }

    private void HandleSwipe()
    {
        Vector2 swipeDelta = endTouchPosition - startTouchPosition;

        if (swipeDelta.magnitude >= swipeThreshold)
        {
            float swipeHorizontal = swipeDelta.x;
            float swipeVertical = swipeDelta.y;

            if (Mathf.Abs(swipeHorizontal) > Mathf.Abs(swipeVertical))
            {
                // Horizontal swipe
                if (swipeHorizontal > 0)
                {
                    OnSwipeRight();
                }
                else
                {
                    OnSwipeLeft();
                }
            }
            else
            {
                // Vertical swipe
                if (swipeVertical > 0)
                {
                    OnSwipeUp();
                }
                else
                {
                    OnSwipeDown();
                }
            }
        }
    }

    private void OnSwipeLeft()
    {
        _player.MoveLeftSide();
    }

    private void OnSwipeRight()
    {
        _player.MoveRightSide();
    }

    private void OnSwipeUp()
    {
        _player.mobile_jump();
    }

    private void OnSwipeDown()
    {
       _player.slide_mobile();
    }
}
