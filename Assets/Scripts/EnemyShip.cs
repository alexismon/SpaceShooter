using System.Collections;
using UnityEngine;

public class EnemyShip : Enemy
{
    public float movementWidth = 5f; // Half the width of the movement range
    public float minHorizontalSpeed = 1f; // Minimum horizontal speed
    public float maxHorizontalSpeed = 3f; // Maximum horizontal speed
    public float fireRate = 2f; // Time between shots
    public Transform[] firePoints; // Points where bullets are spawned
    public GameObject bulletPrefab; // Bullet prefab to spawn

    private float direction = 1; // Direction of horizontal movement
    private float initialX;
    private float horizontalSpeed; // Random horizontal speed

    new void Start()
    {
        base.Start(); // Call the base Start method

        // Store the initial x position
        initialX = transform.position.x;

        // Initialize a random horizontal speed within the specified range
        horizontalSpeed = Random.Range(minHorizontalSpeed, maxHorizontalSpeed);

        // Start the firing coroutine
        StartCoroutine(FireBullets());
    }

    new void Update()
    {
        base.Update(); // Call the base Update method

        // Horizontal movement logic
        Vector3 position = transform.position;
        position.x += direction * horizontalSpeed * Time.deltaTime;

        // Reverse direction if it reaches the boundaries
        if (position.x < initialX - movementWidth || position.x > initialX + movementWidth)
        {
            direction *= -1;
        }

        // Apply the horizontal movement
        transform.position = position;
    }

    IEnumerator FireBullets()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);

            foreach (Transform firePoint in firePoints)
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            }
        }
    }
}
