using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _bottomBound;
    [SerializeField] private float _cooldownPercentOffset = 0.25f;
    private float _nextSpawnTime;
    [SerializeField] private List<SpawnableEnemy> _spawnableEnemies = new List<SpawnableEnemy>();
    [SerializeField] private Transform _topBound;
    private float _totalWeight;

    private void Awake()
    {
        _totalWeight = _spawnableEnemies.Sum(se => se.Weight);
    }

    private void Update()
    {
        if (Time.time < _nextSpawnTime) return;

        var nextSpawnableEnemy = GetNextSpawnableEnemy();

        var instance = Instantiate(nextSpawnableEnemy.Enemy);
        instance.transform.position = new Vector3(transform.position.x, Random.Range(_bottomBound.position.y, _topBound.position.y), 0);

        _nextSpawnTime = Time.time + Random.Range(nextSpawnableEnemy.Cooldown * (1-_cooldownPercentOffset), nextSpawnableEnemy.Cooldown * (1+_cooldownPercentOffset));
    }

    private SpawnableEnemy GetNextSpawnableEnemy()
    {
        var targetWeight = Random.Range(0, _totalWeight);
        float currentWeightSum = 0;
        foreach (var spawnableEnemy in _spawnableEnemies)
        {
            currentWeightSum += spawnableEnemy.Weight;
            if (targetWeight <= currentWeightSum)
                return spawnableEnemy;
        }

        return new SpawnableEnemy();
    }

    [Serializable]
    private struct SpawnableEnemy
    {
        public GameObject Enemy;
        public float Weight;
        public float Cooldown;
    }
}