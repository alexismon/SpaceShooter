using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int scoreValue = 100;
    public int damage = 1;
    public int startingHealth = 10;
    public SpriteRenderer damagedSprite;
    public float maxOpacityAtPercent = 0.75f;
    public GameObject explosionPrefab;
    public float minSize = -0.5f;
    public float maxSize = 1f;
    public float minVelocity = -3;
    public float maxVelocity = -7;
    public AkEvent damagedAkEvent;

    private int health = 0;
    protected Rigidbody2D rigid;
    private Vector2 velocity;
    private Vector3 bottomLeft;

    protected void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        health = startingHealth;

        UpdateDamaged();

        float randScale = Random.Range(minSize, maxSize);
        Vector3 scale = transform.localScale + new Vector3(randScale, randScale, randScale);

        transform.localScale = scale;

        velocity = new Vector2(0, Random.Range(minVelocity, maxVelocity));
    }

    protected void Update()
    {
        rigid.velocity = velocity;

        DestroyOnExit();
    }

    protected void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collider.GetComponent<Bullet>();

            if (bullet != null)
            {
                damagedAkEvent.HandleEvent(gameObject);

                health -= bullet.damage;

                Destroy(collider.gameObject);

                if (health <= 0)
                {
                    ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

                    if (scoreManager != null)
                    {
                        scoreManager.AddScore(scoreValue);
                    }

                    if (explosionPrefab != null)
                    {
                        Instantiate(explosionPrefab, transform.position, transform.rotation);
                    }

                    Destroy(gameObject);
                }
                else
                {
                    UpdateDamaged();
                }
            }
        }
    }

    void UpdateDamaged()
    {
        if (damagedSprite == null)
        {
            return;
        }

        Color color = damagedSprite.color;
        color.a = (1 - ((float)health / (float)startingHealth)) / maxOpacityAtPercent;
        damagedSprite.color = color;
    }

    protected void DestroyOnExit()
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
