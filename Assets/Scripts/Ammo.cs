using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int ammoValue = 1;
    public float minSize = -0.5f;
    public float maxSize = 1f;
    public float minVelocity = -3;
    public float maxVelocity = -7;
    
    private Rigidbody2D rigid;
    private Vector2 velocity;
    private Vector3 bottomLeft;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        
        float randScale = Random.Range(minSize, maxSize);
        Vector3 scale = transform.localScale + new Vector3(randScale, randScale, randScale);

        transform.localScale = scale;

        velocity = new Vector2(0, Random.Range(minVelocity, maxVelocity));
    }

    void Update()
    {
        rigid.velocity = velocity;

        DestroyOnExit();
    }

    void DestroyOnExit()
    {
        Collider2D col = GetComponent<Collider2D>();
        Vector3 sizeBuffer = col.bounds.extents;

        bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)) - sizeBuffer;

        if (transform.position.y < bottomLeft.y)
        {
            Destroy(gameObject);
        }
    }
}
