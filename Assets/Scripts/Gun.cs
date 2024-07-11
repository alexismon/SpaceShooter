using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float fireDelay = 0.25f;
    public float currentFireDelay = 0;
    
    void Update()
    {
        currentFireDelay += Time.deltaTime;

        if (currentFireDelay < fireDelay)
        {
            return;
        }

        if (DoingFireInput())
        {
            currentFireDelay = 0;
            SpawnBullets();
        }
    }
    
    protected virtual bool DoingFireInput()
    {
        return Input.GetButtonDown("Fire");
    }

    protected virtual void SpawnBullets()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
