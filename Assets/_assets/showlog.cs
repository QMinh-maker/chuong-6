using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showlog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update called! " + Time.frameCount);
    }
}
