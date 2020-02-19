using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour
{

    public float shotSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * shotSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if (!this.GetComponent<MeshRenderer>().isVisible)
        {
            PoolMember poolMember = GetComponent<PoolMember>();
            if (poolMember == null)
            {
                Debug.Log("Simple destroy on " + this.name);
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("Repool on " + this.name);
                poolMember.Repool();
            }
        }

    }
}
