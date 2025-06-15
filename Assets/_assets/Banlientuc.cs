using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banlientuc : MonoBehaviour
{
    public GameObject bulletPrefabs;
    public float shootingInterval;
    private float lastBulletTime;
    public Vector3 bulletOffset;

    private void UpdateFiring()
    {
        if (Time.time - lastBulletTime > shootingInterval)
        {
            ShootBullet();
            lastBulletTime = Time.time;
        }
    }
    private void ShootBullet()
    {
        var bullet = Instantiate(bulletPrefabs, transform.position + bulletOffset, transform.rotation);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            UpdateFiring();
        }
    }
}
    
    // Update is called once per frame

    //void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        if(Time.time - lastBulletTime > shootingInterval)
    //        {
    //            ShootBullet();
    //            lastBulletTime = Time.time;
    //        }
    //    }
    //}

