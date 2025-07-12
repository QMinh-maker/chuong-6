using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Kéo‑thả nhân vật: chỉ phản hồi khi người chơi
/// chạm vào collider của chính nhân vật.
/// Hoạt động được cả trên thiết bị di động (touch)
/// lẫn trong Editor (chuột).
/// </summary>
[RequireComponent(typeof(Collider2D))]          // cần 1 collider 2D
public class NewPlayerMove : MonoBehaviour
{
    [SerializeField] private float yOffset = 0.5f;   // giữ khoảng cách đầu nhân vật

    
    private int draggingFingerId = -1;               // ID ngón tay đang điều khiển (–1 = không có)

    void Update()
    {
        // ‑‑‑‑ TOUCH (device) ‑‑‑‑
        if (Input.touchSupported && Input.touchCount > 0)
        {
            HandleTouch();
        }
        // ‑‑‑‑ MOUSE (Editor) ‑‑‑‑
        else if (Input.GetMouseButton(0))
        {
            HandleMouse();
        }
    }

   

    private void HandleTouch()
    {
        foreach (Touch t in Input.touches)
        {
            switch (t.phase)
            {
                case TouchPhase.Began:
                    if (draggingFingerId == -1 && IsTouchOnPlayer(t.position))
                        draggingFingerId = t.fingerId;
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    if (t.fingerId == draggingFingerId)
                        MoveToScreenPoint(t.position);
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if (t.fingerId == draggingFingerId)
                        draggingFingerId = -1;
                    break;
            }
        }
    }

    private void HandleMouse()
    {
        // Bắt đầu kéo
        if (Input.GetMouseButtonDown(0) && IsTouchOnPlayer(Input.mousePosition))
            draggingFingerId = 0;

        // Đang kéo
        if (draggingFingerId == 0 && Input.GetMouseButton(0))
            MoveToScreenPoint(Input.mousePosition);

        // Thả ra
        if (Input.GetMouseButtonUp(0) && draggingFingerId == 0)
            draggingFingerId = -1;
    }

    /// <summary>Kiểm tra cú chạm/chuột có nằm trên collider của chính nhân vật không.</summary>
    private bool IsTouchOnPlayer(Vector3 screenPos)
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPos);
        // Va chạm 2D chỉ cần Collider2D
        return Physics2D.OverlapPoint(worldPoint) == GetComponent<Collider2D>();
    }

    /// <summary>Di chuyển nhân vật tới toạ độ màn hình (giữ z = 0).</summary>
    private void MoveToScreenPoint(Vector3 screenPos)
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(screenPos);
        worldPoint.z = 0;
        worldPoint.y += yOffset;
        transform.position = worldPoint;
    }
}

