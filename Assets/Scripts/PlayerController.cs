using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;
    public float topBound = 15.0f;
    public float bottomBound = -1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        // keep the player in range

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3 (xRange, 0, transform.position.z);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3 (-xRange, 0, transform.position.z);
        }
        if (transform.position.z > topBound)
        {
            transform.position = new Vector3 (transform.position.x, 0, topBound);
        }
        if (transform.position.z < bottomBound)
        {
            transform.position = new Vector3 (transform.position.x, 0, bottomBound);
        }

        // shoot

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // launch a projectile
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectilePrefab.transform.rotation);
            Debug.Log("space is pressed");
        }
    }
}
