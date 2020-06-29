using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 _currentTarget;
    public void Start()
    {
        _currentTarget = pointB.position;
    }

    public override void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (this.transform.position == pointA.position)
        {
            _currentTarget = pointB.position;

        }
        else if (this.transform.position == pointB.position)
        {
            _currentTarget = pointA.position;

        }
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    }
}
