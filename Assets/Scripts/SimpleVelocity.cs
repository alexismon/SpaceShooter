using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleVelocity : MonoBehaviour
{
    public float velocity;
    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigid.velocity = transform.up * velocity;
    }
}
