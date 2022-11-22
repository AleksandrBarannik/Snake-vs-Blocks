using System;
using System.Collections;
using System.Collections.Generic;
using AllForSnake;
using UnityEngine;

public class DiffucltController : MonoBehaviour
{
    [SerializeField] private float distanceToIncrease = 2;
    [SerializeField] private float factorIncrease = 0.1f;

    private Vector3 _lastPosition;


    private void Start()
    {
        _lastPosition = SnakeHead.Instance.transform.position;
    }

    private void Update()
    {
        if (_lastPosition.y + distanceToIncrease <=SnakeHead.Instance.transform.position.y)
        {
            _lastPosition = SnakeHead.Instance.transform.position;

            Snake.Instance.Speed *= factorIncrease + 1;
            Snake.Instance.TailSpringiness *= factorIncrease + 1;
            
            
        }
    }
}
