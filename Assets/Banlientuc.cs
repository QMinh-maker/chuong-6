using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banlientuc : MonoBehaviour
{
    
    
    public GameObject bulletPrefabs;
    public float shootingInterval;
    private float lastBulletTime;

    private void ShootBullet()
    {
        Instantiate(bulletPrefabs, transform.position, transform.rotation);
    }
    // Update is called once per frame

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(Time.time - lastBulletTime > shootingInterval)
            {
                ShootBullet();
                lastBulletTime = Time.time;
            }
        }
    }
}
