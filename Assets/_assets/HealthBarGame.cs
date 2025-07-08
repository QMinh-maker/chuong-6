using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarGame : MonoBehaviour
{
    public RectTransform mask;
    public Health health;
    
    private float originalWidth;
    void Start()
    {
        originalWidth = mask.sizeDelta.x;
        UpdateHealthValue();
        health.onHealthChanged += UpdateHealthValue;
    }

    // Update is called once per frame
    private void UpdateHealthValue()
    {
        float scale = (float)health.healthPoint / health.defaultHealthPoint;
        mask.sizeDelta = new Vector2(scale * originalWidth, mask.sizeDelta.y);
    }
}
