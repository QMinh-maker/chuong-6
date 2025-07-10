using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [System.Serializable]
    public class EnemyWave 
    {
        public Transform enemyPrefab;
        public int numberOfEnemy;
        public Vector3 formationOffset;
        public FlyPath flyPath;
        public float speed;
        public float nextWaveDelay;
    }
    public EnemyWave[] enemyWaves;
    private int currentWave;
    void Start()
    {
        SpawnEnemyWave();
    }

    // Update is called once per frame
    private void SpawnEnemyWave()
    {
        var waveInfo = enemyWaves[currentWave];
        var startPosition = waveInfo.flyPath[0];
        
        for (int i = 0; i < waveInfo.numberOfEnemy; i++)
        {
            var enemy = Instantiate(waveInfo.enemyPrefab, startPosition, Quaternion.identity);
            var agent = enemy.GetComponent<FlyPathAgent>();
            agent.flyPath = waveInfo.flyPath;
            agent.flySpeed = waveInfo.speed;
            startPosition += waveInfo.formationOffset;
        }

        currentWave++;
        if (currentWave < enemyWaves.Length)
        {
            Invoke(nameof(SpawnEnemyWave), waveInfo.nextWaveDelay);
        }

    }
}
