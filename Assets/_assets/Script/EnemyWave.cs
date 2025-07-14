using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/Enemy Wave")]
public class EnemyWave : ScriptableObject
{
    public Transform enemyPrefab;
    
    public int numberOfEnemy ;
    public Vector3 formationOffset ;
    public FlyPath flyPath ;
    public float speed ;
    public float nextWaveDelay ;
}
