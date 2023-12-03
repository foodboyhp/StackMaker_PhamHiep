using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleBrick :Brick
{
    [SerializeField] private GameObject brickMesh;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(brickMesh);
        }
    }
}
