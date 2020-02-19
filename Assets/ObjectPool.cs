using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    // Editor-controlled values: What kind of GameObject is in this pool,
    // and how many should we have in there?
    public GameObject prefab;
    public int objectsInPool;


    // Queue: First-in, first-out; last-in, last-out,
    // allows us to keep high performance despite not knowing
    // what order objects will be returned to the pool.
    private Queue<GameObject> pool = new Queue<GameObject>();


    // Initialize the pool: Create the objects, but deactivate and store them
    void Start()
    {
        Debug.Log("Pool spinning up");
        for (int i = 0; i < objectsInPool; i++)
        {
            GameObject pooledObject = Instantiate(prefab);
            pooledObject.GetComponent<PoolMember>().pool = this;
            pooledObject.SetActive(false);
            pooledObject.transform.parent = transform;
            pool.Enqueue(pooledObject);
        }
    }


    // Anything using this pool for objects should use this method
    // instead of calling Instantiate, which can be slow.
    public GameObject GetFromPool()
    {
        GameObject next = pool.Dequeue();
        next.transform.parent = null;
        next.SetActive(true);
        return next;
    }


    // Anything using this pool for objects should use this method
    // instead of calling Destroy, so that the object is recycled.
    public void ReturnToPool(GameObject o)
    {
        o.transform.parent = transform;
        o.SetActive(false);
        pool.Enqueue(o);
    }

}
