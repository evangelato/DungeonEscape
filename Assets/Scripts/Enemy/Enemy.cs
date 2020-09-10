﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;
    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected bool isHit = false;

    // Variable to store the player
    protected Player player;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        currentTarget = pointB.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); ;
    }

    private void Start()
    {
        Init();
    }
    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !anim.GetBool("InCombat"))
        {
            return;
        }

        Movement();
    }

    public virtual void Movement()
    {
        if (currentTarget == pointA.position)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
        if (this.transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");

        }
        else if (this.transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");

        }
        if (!isHit)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        // Check for distance between player and enemy
        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        if (distance > 2.0f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }

        Vector3 direction = player.transform.localPosition - transform.localPosition;

        if (direction.x > 0 && anim.GetBool("InCombat"))
        {
            sprite.flipX = false;
        }
        else if (direction.x < 0 && anim.GetBool("InCombat"))
        {
            sprite.flipX = true;
        }
    }

    public virtual void Attack()
    {
        Debug.Log("My name is: " + this.gameObject.name);
    }



}
