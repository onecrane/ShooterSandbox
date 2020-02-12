using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelConveyor : MonoBehaviour
{

    public float endZ = -162;
    public float scrollSpeed = 10;

    private float currentZ = 0;

    public bool isLevelPlaying = true;

    public float timeToRestart = 3.0f;  // seconds
    private float restartTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLevelPlaying)
        {
            UpdateLevelInPlay();
        } else
        {
            HandleRestart();
        }
    }

    void HandleRestart()
    {
        restartTimer -= Time.deltaTime;
        if (restartTimer <= 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void UpdateLevelInPlay()
    {
        Vector3 movement = new Vector3(0, 0, endZ - transform.position.z);
        movement.Normalize();
        movement *= scrollSpeed * Time.deltaTime;

        transform.position += movement;

        if (transform.position.z <= endZ)
        {
            StopLevel();
        }

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject == null)
        {
            StopLevel();
        }
    }

    void StopLevel()
    {
        scrollSpeed = 0;
        isLevelPlaying = false;
        restartTimer = timeToRestart;
    }



}
