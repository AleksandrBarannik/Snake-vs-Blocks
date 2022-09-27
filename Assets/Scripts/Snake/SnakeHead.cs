using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SnakeHead : MonoBehaviour
{
    private Rigidbody2D _rigitBody2d;

    private void Start()
    {
        _rigitBody2d = GetComponent<Rigidbody2D>();
    }

    public void Move( Vector3 newPosition)
    {
        _rigitBody2d.MovePosition(newPosition);
    }
}
