using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepoolOnCollision : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<PoolMember>().Repool();
    }
}
