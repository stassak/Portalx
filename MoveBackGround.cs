using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackGround : MonoBehaviour
{
    private Vector3 startGroundPos;
    // Start is called before the first frame update
    void Start()
    {
        startGroundPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < startGroundPos.z - 100)
        {
            transform.position = startGroundPos;
        }
    }
}
