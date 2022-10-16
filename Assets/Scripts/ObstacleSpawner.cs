using System;
using System.Collections;
using System.Collections.Generic;
using AllForSnake;
using Common;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 4;
    
    
    [Header("Blocks")]
    [SerializeField] private Transform[] points;
    [SerializeField] private GameObject[] blocks;
    [SerializeField] private Transform blocksParent;
    

    [Header("Bounus")] 
    [SerializeField] private Vector[] spawnVectors;
    [SerializeField] private GameObject[] bonus;
    [SerializeField] private Transform BonusesParent;

    private float _targetY;

    private void Start()
    {
        _targetY = transform.position.y + spawnRate;
        
        CreateLine();
        CreateBonus();
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, SnakeHead.Instance.transform.position.y);

        if (transform.position.y >= _targetY)
        {
            CreateLine();
            CreateBonus();
            
            _targetY = transform.position.y + spawnRate;
        }
    }

    private void CreateLine()
    {
        foreach (var point in points)
        {
            CreateBlock(point);
        }

       
    }
    
    private void CreateBlock(Transform point)
    {
        GameObject bloks = Instantiate(blocks[Random.Range(0, blocks.Length)],
            point.position, Quaternion.identity,blocksParent);
    }

    private void CreateBonus()
    {
        foreach (var vector in spawnVectors)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(vector.beginPoint.position.x, vector.endPoint.position.x),
                vector.beginPoint.position.y);

            Instantiate(bonus[Random.Range(0, bonus.Length)],
                spawnPosition, Quaternion.identity,BonusesParent);
        }
    }
}
