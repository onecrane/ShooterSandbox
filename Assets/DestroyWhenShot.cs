using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenShot : MonoBehaviour
{

    public LayerMask killLayers;

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
        if ((killLayers.value & (1 << collision.gameObject.layer)) > 0) Destroy(this.gameObject);
    }
}
