using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour
{

    public float shotSpeed = 100f;
    public float maxZ = 83;
    public float minZ = -20;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * shotSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > maxZ || transform.position.z < minZ)
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
}
