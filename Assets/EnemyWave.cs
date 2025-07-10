
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public Transform enemyPrefab;
    public int numberOfEnemy;
    public Vector3 formationOffset;
    public FlyPath flyPath;
    public float speed;
    public float nextWaveDelay;
}
