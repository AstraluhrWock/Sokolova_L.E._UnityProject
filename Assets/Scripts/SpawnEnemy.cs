using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnStep = 1f;
    private float _lifeTime = .5f;
    private float _nextSpawnTime;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextSpawnTime)
        {
            var enemy = Instantiate(_enemyPrefab, transform);
            _nextSpawnTime = Time.time + _spawnStep;
            Destroy(enemy.gameObject, _lifeTime);
        }
    }
}
