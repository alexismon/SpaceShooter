using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3;
    public int startingHealth = 3;
    public HealthBar healthBar;
    private Rigidbody2D rigid;
    public GameObject explosionPrefab;
    public RandomAudioSource ammoBoxAudioSource;
    public RandomAudioSource damageAudioSource;

    private int health = 0;
    private Vector3 minPosition = new Vector2(-5, -5);
    private Vector3 maxPosition = new Vector2(5, 5);
    

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>(); //Get RigidBody 2D Component from GameObject and assign to variable

        Collider2D col = GetComponent<Collider2D>();
        Vector3 sizeBuffer = col.bounds.extents;

        Camera cam = Camera.main;
        minPosition = cam.ViewportToWorldPoint(new Vector3(0, 0)) + sizeBuffer;
        maxPosition = cam.ViewportToWorldPoint(new Vector3(1, 1)) - sizeBuffer;

        health = startingHealth;
        healthBar.UpdateHealthUI(health);
    }

    void Update()
    {
        Vector2 velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed; //Get Input from the InputManager
        rigid.velocity = velocity;

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, minPosition.x, maxPosition.x);
        position.y = Mathf.Clamp(position.y, minPosition.y, maxPosition.y);
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyShip") || collision.gameObject.CompareTag("EnemyBullet"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();

            if (enemy != null || bullet != null)
            {
                damageAudioSource.Play();

                if (enemy != null)
                {
                    health -= enemy.damage;

                    if (enemy.explosionPrefab != null)
                    {
                        Instantiate(enemy.explosionPrefab, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                    }
                }
                else if (bullet != null)
                {
                    health -= bullet.damage;
                }

                healthBar.UpdateHealthUI(health);

                Destroy(collision.gameObject);

                if (health <= 0)
                {
                    Destroy(gameObject);

                    if (explosionPrefab != null)
                    {
                        Instantiate(explosionPrefab, transform.position, transform.rotation);
                    }

                    GameScreen gameScreen = FindObjectOfType<GameScreen>();

                    if (gameScreen != null)
                    {
                        gameScreen.OnPlayerDeath();
                    }
                }
            }
        }
        else if (collision.gameObject.CompareTag("Ammo"))
        {
            Destroy(collision.gameObject);

            ammoBoxAudioSource.Play();

            AmmoManager ammoManager = FindAnyObjectByType<AmmoManager>();

            ammoManager.AddSpecialAmmo(1);
        }
    }
}
