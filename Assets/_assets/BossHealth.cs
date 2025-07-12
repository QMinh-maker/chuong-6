using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : Health
{
    [SerializeField] private BattleFlow battleFlow;

    private void Awake()
    {
        
        battleFlow = BattleFlow.Instance;
    }


    protected override void Die()
    {
        base.Die();                         

        
        if (battleFlow != null)
            battleFlow.ShowWin();           
        else
            Debug.LogWarning("BattleFlow reference missing on Boss!");
    }
}

