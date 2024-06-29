using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class RandomPoint : MonoBehaviour
    {
        [SerializeField] private Collider _gameBoard;
        
        public Vector3 GetRandomPoint()
        {
            var bounds = _gameBoard.bounds;
            var randomX = Random.Range(bounds.min.x, bounds.max.x);
            var randomZ = Random.Range(bounds.min.z, bounds.max.z);
            return new Vector3(randomX, 0, randomZ);
        }
    }
}