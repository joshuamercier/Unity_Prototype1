using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObstacles : MonoBehaviour
{
    // Class variables
    public float speed = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
