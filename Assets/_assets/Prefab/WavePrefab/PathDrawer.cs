using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class PathDrawer : MonoBehaviour
{
    public Transform[] waypoints;
    public int resolution = 10;

    private void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Length < 2)
            return;

        Gizmos.color = Color.green;

        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            Vector3 p0 = waypoints[Mathf.Max(i - 1, 0)].position;
            Vector3 p1 = waypoints[i].position;
            Vector3 p2 = waypoints[i + 1].position;
            Vector3 p3 = waypoints[Mathf.Min(i + 2, waypoints.Length - 1)].position;

            Vector3 lastPos = p1;
            for (int j = 1; j <= resolution; j++)
            {
                float t = j / (float)resolution;
                Vector3 newPos = CatmullRom(p0, p1, p2, p3, t);
                Gizmos.DrawLine(lastPos, newPos);
                lastPos = newPos;
            }
        }
    }

    Vector3 CatmullRom(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        return 0.5f * ((2f * p1) +
                      (-p0 + p2) * t +
                      (2f * p0 - 5f * p1 + 4f * p2 - p3) * t * t +
                      (-p0 + 3f * p1 - 3f * p2 + p3) * t * t * t);
    }
}


