using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRepeat : MonoBehaviour
{
    private Vector3 startpPos;
    private float  speedBackGround= 10;
    // Start is called before the first frame update
    void Start()
    {
        startpPos = transform.position;
        transform.Translate(Vector3.left * Time.deltaTime * speedBackGround);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < startpPos.z - 40)
        {
          transform.position = startpPos;
        }
    }
}
