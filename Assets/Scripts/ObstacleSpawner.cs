using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 4f;
    
    //[SerializeField] private AnimationCurve dificultCurve;
    
    [Header("Blocks")]
    [SerializeField] private Transform[] points;
    [SerializeField] private GameObject[] blocks;
    [SerializeField] private Transform blocksParent;

    [Header("Bounus")] 
    [SerializeField] private Transform beginPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private GameObject[] bonus;
    [SerializeField] private Transform BonusesParent;

    private int _spawnedLines = 0;

    private void Start()
    {
        InvokeRepeating(nameof(CreateLine), 0, spawnRate);
        InvokeRepeating(nameof(CreateBonus), 0, spawnRate);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime);
    }

    private void CreateLine()
    {
        foreach (var point in points)
        {
            CreateBlock(point);
        }

        _spawnedLines++;
        
        
        // TODO спавнится блок финиша (финищная черта) (спаунслайн сравнивать с какой -то перемоной количество линий в которой содержится
    }
    
    private void CreateBlock(Transform point)
    {
        GameObject bloks = Instantiate(blocks[Random.Range(0, blocks.Length)], point.position, Quaternion.identity);
        bloks.transform.SetParent(blocksParent);
    }

    private void CreateBonus()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(beginPoint.position.x, endPoint.position.x),
            beginPoint.position.y);

        GameObject bonuses = Instantiate(bonus[Random.Range(0, bonus.Length)], spawnPosition, Quaternion.identity);
        bonuses.transform.SetParent(BonusesParent);
    }
}
