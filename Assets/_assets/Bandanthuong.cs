using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandanthuong : MonoBehaviour
{
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}
