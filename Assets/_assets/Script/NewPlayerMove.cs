using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewPlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector3? targetPosition = null;


    private void Update()
    {
        HandleInput();
        MoveToTarget();
    }

    void HandleInput()
    {
        // Input trên thiết bị di động (touch)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                Vector3 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);
                worldPoint.z = 0;
                targetPosition = worldPoint;
            }
        }

        
        if (Input.GetMouseButton(0))
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPoint.z = 0;
            targetPosition = worldPoint;
        }
    }
    //Input trên máy tính (chuột trái)
    void MoveToTarget()
    {
        if (targetPosition.HasValue)
        {
            Vector3 direction = (targetPosition.Value - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, targetPosition.Value);

            if (distance > 0.05f)
            {
                transform.position += direction * moveSpeed * Time.deltaTime;
            }
            else
            {
                transform.position = targetPosition.Value;
                targetPosition = null;
            }
        }
    }
}

