using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMember : MonoBehaviour
{

    public ObjectPool pool;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // To be used in place of Destroy()
    public void Repool()
    {
        pool.AddToPool(this.gameObject);
    }
}
