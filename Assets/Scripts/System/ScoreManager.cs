using System;
using System.Collections;
using System.Collections.Generic;
using AllForSnake;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    
    public int Score => Mathf.RoundToInt(SnakeHead.Instance.transform.position.y);

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
}
