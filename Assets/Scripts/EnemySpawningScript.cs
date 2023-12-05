using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningScript : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private int _max;// = 13;
    private float _enemyInterval;// = 1.0f;
    private const float StartInterval = 30.0f;
    private bool _isGenerating = false;
    private int _generatedEnemies = 0;
    private System.DateTime _startTime;
    
    private void Start()
    {
        _startTime = System.DateTime.UtcNow;
        //if (!_firstRun) return;
        //_firstRun = false;
        //Debug.Log($"1. max:{_max}, enemyInterval:{_enemyInterval}");
        _max = PlayerPrefs.GetInt("maxEnemySpawn");
        _enemyInterval = PlayerPrefs.GetFloat("enemyInterval");
        //Debug.Log($"2. max:{_max}, enemyInterval:{_enemyInterval}");
        // Only for testing when PlayerPrefs not saved
        if (_max != 0) return;
        _max = 13;
        _enemyInterval = 1.0f;
        //Debug.Log($"3. max:{_max}, enemyInterval:{_enemyInterval}");
    }

    private void Update()
    {
        if (_isGenerating) return;
        var ts = System.DateTime.UtcNow - _startTime;
        if (ts.Seconds < 1 || ts.Seconds % StartInterval != 0) return;
        StartCoroutine(Generate());
        //Debug.Log($"max:{_max}, interval:${_enemyInterval}");
    }

    private IEnumerator Generate()
    {
        _isGenerating = true;
        while(_generatedEnemies < _max)
        {
            var ts = System.DateTime.UtcNow - _startTime;
            if (ts.Seconds < StartInterval) continue;
            if (ts.Seconds % _enemyInterval != 0) continue;
            
            var transform1 = transform;
            var enemy = Instantiate(enemyPrefab, transform1.position, transform1.rotation);
            enemy.transform.SetParent(gameObject.transform);
            ++_generatedEnemies;
            yield return StartCoroutine(Wait(_enemyInterval));
        }
        _isGenerating = false;
        _generatedEnemies = 0;
    }
    
    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
