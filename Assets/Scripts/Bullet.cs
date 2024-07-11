using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;

    private Vector3 topRight;

    void Update()
    {
        DestroyOnExit();
    }

    void DestroyOnExit()
    {
        Collider2D col = GetComponent<Collider2D>();
        Vector3 sizeBuffer = col.bounds.extents;

        topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1)) + sizeBuffer;

        if (transform.position.y > topRight.y)
        {
            Destroy(gameObject);
        }
    }
}
