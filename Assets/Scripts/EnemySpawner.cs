using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private UnityEvent<Dictionary<Color,int>> _ColorsCount;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _enemyCounts = 6;
    private RandomPoint _randomPoint;
    private Colors _colors;
    private Dictionary<Color, int> _dictionary = new();

    public void Initialize(RandomPoint randomPoint, Colors colors)
    {
        _randomPoint = randomPoint;
        _colors = colors;
        var temp = _colors.GetColors();
        foreach (var t in temp)
        {
            _dictionary.Add(t, 0);
        }
        for (int i = 0; i < _enemyCounts; i++)
        {
            var position = _randomPoint.GetRandomPoint();
            var enemy = Instantiate(_enemyPrefab);
            enemy.transform.position = position;
            enemy.Initialize(_colors.SetColor());
            TakeColorInDict(enemy);
        }
        _ColorsCount.Invoke(_dictionary);
    }

    private void TakeColorInDict(Enemy enemy)
    {
        if (_dictionary.ContainsKey(enemy.Color))
        {
            _dictionary[enemy.Color] += 1;
        }
    }
}
