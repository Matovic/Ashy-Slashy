using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningScript : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private int _max = 13;
    private const float StartInterval = 30.0f, EnemyInterval = 1.0f;
    private bool _isGenerating = false;
    private int _generatedEnemies = 0;
    private System.DateTime _startTime;
    
    private void Start()
    {
        _startTime = System.DateTime.UtcNow;
    }

    private void Update()
    {
        if (_isGenerating) return;
        var ts = System.DateTime.UtcNow - _startTime;
        if (ts.Seconds < 1 || ts.Seconds % StartInterval != 0) return;
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        _isGenerating = true;
        while(_generatedEnemies < _max)
        {
            var ts = System.DateTime.UtcNow - _startTime;
            if (ts.Seconds < StartInterval) continue;
            if (ts.Seconds % EnemyInterval != 0) continue;
            
            var transform1 = transform;
            var enemy = Instantiate(enemyPrefab, transform1.position, transform1.rotation);
            enemy.transform.SetParent(gameObject.transform);
            ++_generatedEnemies;
            yield return StartCoroutine(Wait(1.0f));
        }
        _isGenerating = false;
        _generatedEnemies = 0;
    }
    
    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
