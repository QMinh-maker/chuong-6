using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossFlyPath : MonoBehaviour
{
    [Header("Path")]
    public FlyPath flyPath;          

    [Header("Move")]
    public float flySpeed = 2f;     

    private int nextIndex;           

    
    private void Start()
    {
        if (flyPath == null || flyPath.waypoints == null || flyPath.waypoints.Length == 0)
        {
            Debug.LogError($"{name}: FlyPath (hoặc mảng waypoints) chưa được gán!");
            enabled = false;
            return;
        }

    
        transform.position = GetWaypointPos(0);
        nextIndex = 1 % flyPath.waypoints.Length;
    }

    
    private void Update()
    {
        if (flyPath == null) return;                          

        Vector3 targetPos = GetWaypointPos(nextIndex);

        
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            flySpeed * Time.deltaTime);

        RotateTowards(targetPos);

        
        if (Vector3.Distance(transform.position, targetPos) < 0.05f)
        {
            nextIndex++;

            
            if (nextIndex >= flyPath.waypoints.Length)
                nextIndex = 0;
        }
    }

    
    private Vector3 GetWaypointPos(int index)
    {
       
        return flyPath.waypoints[index].transform.position;
    }

   
    private void RotateTowards(Vector3 targetPos)
    {
        Vector2 dir = targetPos - transform.position;
        if (dir.sqrMagnitude < 0.0001f) return;

        float angle = Vector2.SignedAngle(Vector2.down, dir);   
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}


