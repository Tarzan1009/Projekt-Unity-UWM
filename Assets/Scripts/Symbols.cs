using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbols : MonoBehaviour
{
    public float rpm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, rpm * Time.deltaTime * 6, 0.0f);
    }
}
