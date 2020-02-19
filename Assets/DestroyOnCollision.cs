using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        PoolMember poolMember = GetComponent<PoolMember>();
        if (poolMember == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            poolMember.Repool();
        }

    }
}
