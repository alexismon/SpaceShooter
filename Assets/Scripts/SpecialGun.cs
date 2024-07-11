using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialGun : Gun
{
    public Transform[] firePoints;
    public int ammoCost = 1;

    private AmmoManager ammoManager;

    private void Start()
    {
        ammoManager = FindObjectOfType<AmmoManager>();
    }

    protected override bool DoingFireInput()
    {
        return Input.GetButtonDown("Special") && ammoManager.GetSpecialAmmo() >= ammoCost;
    }

    protected override void SpawnBullets()
    {
        ammoManager.AddSpecialAmmo(-ammoCost);

        for (int i = 0; i < firePoints.Length; i++)
        {
           Instantiate(bulletPrefab, firePoints[i].position, firePoints[i].rotation);
        }
    }
}
