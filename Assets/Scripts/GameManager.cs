using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Colors _colors;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Candy _candy;
    [SerializeField] private RandomPoint _randomPointMaker;

    private void Awake()
    {
        _enemySpawner.Initialize(_randomPointMaker, _colors);
        var candy = Instantiate(_candy);
        candy.Initialize(_randomPointMaker, _colors);
    }
}
