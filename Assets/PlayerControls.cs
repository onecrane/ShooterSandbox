using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public float lateralSpeed = 8.0f;

    public float fireRate = 4.0f;   // shots per second
    private float cooldown = 0.0f;

    public float leftBound, rightBound;

    public Transform leftCannon, rightCannon;

    public GameObject basicProjectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageMovement();
        ManageFire();
    }

    void ManageMovement()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movement += -transform.right;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movement += transform.right;
        }

        Vector3 newPosition = transform.position + movement * lateralSpeed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, leftBound, rightBound);
        transform.position = newPosition;
    }

    void ManageFire()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (cooldown <= 0)
            {
                FireShots();
                cooldown = 1.0f / fireRate;
            }
        }
        cooldown -= Time.deltaTime;
    }

    void FireShots()
    {
        GameObject leftShot = Instantiate(basicProjectile);
        leftShot.transform.position = leftCannon.position;

        GameObject rightShot = Instantiate(basicProjectile);
        rightShot.transform.position = rightCannon.position;
    }
}
