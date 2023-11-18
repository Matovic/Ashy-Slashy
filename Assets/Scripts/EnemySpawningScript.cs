using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningScript : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject item;
    [SerializeField] private float interval = 100;
    private int _max = 1;
    private const int StartInterval = 1, EnemyInterval = 1;
    private bool generating = false;
    private int _generatedEnemies = 0;
    private float _counter = 0;
    private System.DateTime _startTime;
    
    private void Start()
    {
        _startTime = System.DateTime.UtcNow;
    }

    private void Update()
    {
        if (_generatedEnemies >= _max) return;
        var ts = System.DateTime.UtcNow - _startTime;
        if (ts.Seconds < StartInterval) return;
        if (ts.Seconds % EnemyInterval != 0) return;
        if (!generating)
        {
            generating = true;
            var transform1 = transform;
            Instantiate(enemyPrefab, transform1.position, transform1.rotation);
            generating = false;
            ++_generatedEnemies;
        }
    }
}
