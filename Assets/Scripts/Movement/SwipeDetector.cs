using System;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    public static event Action<PlayerSwipeDetector> OnSwipe;
    private Vector2 _startTouchPosition;
    private Vector2 _currentTouchPosition;
    private bool _stopTouch = false;
    private const float _swipeRange = 50;
    //private const float _tapRange = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public enum PlayerSwipeDetector
    {
        Up,
        Down,
        Left,
        Right,
        None
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase) 
            {
                case TouchPhase.Began:
                    _startTouchPosition = touch.position;
                    _stopTouch = false;
                    break;

                case TouchPhase.Moved:
                    if (!_stopTouch)
                    {
                        _currentTouchPosition = touch.position;
                        Vector2 swipeDelta = _currentTouchPosition - _startTouchPosition;

                        if (swipeDelta.magnitude > _swipeRange)
                        {
                            _stopTouch = true;
                            PlayerSwipeDetector direction = DetectSwipeDirection(swipeDelta);
                            OnSwipe?.Invoke(direction); // Генерируем событие свайпа
                        }
                    }
                    
                    break;

                case TouchPhase.Ended:
                    //if (!_stopTouch)
                    //{
                    //    Vector2 swipeDelta = _currentTouchPosition - _startTouchPosition;

                    //    if (swipeDelta.magnitude > _swipeRange)
                    //    {
                    //        _stopTouch = true;
                    //        PlayerSwipeDetector direction = DetectSwipeDirection(swipeDelta);
                    //        OnSwipe?.Invoke(direction); // Генерируем событие свайпа
                    //    }
                    //}
                    _stopTouch = true;
                    break;
            }
        }    
    }

    private PlayerSwipeDetector DetectSwipeDirection(Vector2 swipeDelta)
    {
        if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
        {
            return swipeDelta.x > 0 ? PlayerSwipeDetector.Right : PlayerSwipeDetector.Left;
        }
        else
        {
            return swipeDelta.y > 0 ? PlayerSwipeDetector.Up : PlayerSwipeDetector.Down;
        }
    }
}
