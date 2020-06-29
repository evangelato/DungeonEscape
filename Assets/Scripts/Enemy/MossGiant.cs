using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 _currentTarget;
    private Animator _anim;
    private SpriteRenderer _mossGiantSprite;
    public void Start()
    {
        _currentTarget = pointB.position;
        _anim = GetComponentInChildren<Animator>();
        _mossGiantSprite = GetComponentInChildren<SpriteRenderer>();
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
            _mossGiantSprite.flipX = true;
        }
        else
        {
            _mossGiantSprite.flipX = false;
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
