using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autofire : MonoBehaviour
{

    public float fireRate = 1.0f;   // shots per second
    private float cooldown = 0.0f;

    public Transform cannon;
    public GameObject projectile;

    public LevelConveyor levelController;

    // Start is called before the first frame update
    void Start()
    {
        levelController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelConveyor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (levelController.isLevelPlaying)
        {
            ManageFire();
        }
    }

    void ManageFire()
    {
        if (cooldown <= 0)
        {
            FireShots();
            cooldown = 1.0f / fireRate;
        }
        cooldown -= Time.deltaTime;
    }

    void FireShots()
    {
        GameObject shot = Instantiate(projectile, cannon);
        shot.transform.parent = null;
//        shot.transform.position = cannon.position;
    }
}
