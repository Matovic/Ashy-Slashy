using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemies
{
    public class EnemySpawningScript : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [FormerlySerializedAs("StartInterval")] [SerializeField] private float startInterval = 30.0f;
        private int _max;
        private float _enemyInterval;
        private bool _isGenerating = false;
        private int _generatedEnemies = 0;
        private System.DateTime _startTime;
    
        private void Start()
        {
            _startTime = System.DateTime.UtcNow;
            _max = PlayerPrefs.GetInt("maxEnemySpawn");
            _enemyInterval = PlayerPrefs.GetFloat("enemyInterval");
            if (_max != 0) return;
            _max = 13;
            _enemyInterval = 1.0f;
        }

        private void Update()
        {
            if (_isGenerating) return;
            var ts = System.DateTime.UtcNow - _startTime;
            if (ts.Seconds < 1 || ts.Seconds % startInterval != 0) return;
            StartCoroutine(Generate());
        }

        private IEnumerator Generate()
        {
            _isGenerating = true;
            while(_generatedEnemies < _max)
            {
                var ts = System.DateTime.UtcNow - _startTime;
                if (ts.Seconds < startInterval) continue;
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
}
