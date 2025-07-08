using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPath : MonoBehaviour
{
    public WayPoint[] waypoints;

    private void Reset()
    {
        waypoints = GetComponentsInChildren<WayPoint>();
    }
}
