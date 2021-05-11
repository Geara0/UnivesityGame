using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private Vector2 movement;
    private Rigidbody2D rb;
    public float speed;
    public int maxHealth = 10;
    public int currentHealth;
    public HitbarBehaviour healthBar;

    public ProjectileBehaviour projectilePrefab;
    public Transform launchOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetButtonDown("Fire1"))
            Instantiate(projectilePrefab, launchOffset.position, transform.rotation);

    }

    public void TakeHit(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * (speed * Time.deltaTime));
    }
}