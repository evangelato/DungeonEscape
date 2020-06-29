using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    private Vector3 _currentTarget;
    private Animator _anim;
    private SpriteRenderer _spiderSprite;
    private void Start()
    {
        _currentTarget = pointB.position;
        _anim = GetComponentInChildren<Animator>();
        _spiderSprite = GetComponentInChildren<SpriteRenderer>();
    }
    public override void Attack()
    {

    }

    public override void Update()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        Movement();

    }

    void Movement()
    {
        if (_currentTarget == pointA.position)
        {
            _spiderSprite.flipX = true;
        }
        else
        {
            _spiderSprite.flipX = false;
        }

        if (this.transform.position == pointA.position)
        {
            _currentTarget = pointB.position;
            _anim.SetTrigger("Idle");
        }
        else if (this.transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
            _anim.SetTrigger("Idle");
        }
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    }
}
