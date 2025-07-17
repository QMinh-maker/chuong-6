using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewPlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector3? targetPosition = null;

    void Update()
    {
        // Nếu có chạm tay lên màn hình
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Khi người chơi bắt đầu chạm hoặc đang giữ chạm
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                Vector3 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);
                worldPoint.z = 0;
                targetPosition = worldPoint;
            }
        }

        // Di chuyển đến vị trí mục tiêu nếu có
        if (targetPosition.HasValue)
        {
            Vector3 direction = (targetPosition.Value - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, targetPosition.Value);

            // Di chuyển với tốc độ giới hạn theo thời gian
            if (distance > 0.05f)
            {
                transform.position += direction * moveSpeed * Time.deltaTime;
            }
            else
            {
                // Khi đến gần vị trí mục tiêu, dừng lại và xóa target
                transform.position = targetPosition.Value;
                targetPosition = null;
            }
        }
    }
}

