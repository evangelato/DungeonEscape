using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;
    [SerializeField]
    private float _jumpForce = 5;
    [SerializeField]
    private LayerMask _groundLayer;
    [SerializeField]
    private bool _grounded = false;
    private bool resetJumpNeeded = false;
    // Variable for jump force
    // Variable grounded is false using raycasting
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        // If space key and is grounded
        float velocity = _rigid.velocity.y;
        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            _grounded = false;
            resetJumpNeeded = true;
            StartCoroutine(ResetJumpNeededRoutine());
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, _groundLayer.value);
        Debug.DrawRay(transform.position, Vector2.down * 0.7f, Color.green);
        if (hit.collider != null)
        {
            if (!resetJumpNeeded)
            {
                _grounded = true;
            }
        }

        _rigid.velocity = new Vector2(move, _rigid.velocity.y);
    }

    IEnumerator ResetJumpNeededRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        resetJumpNeeded = false;
    }
    /*
    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, _groundLayer.value);
        Debug.DrawRay(transform.position, Vector2.down * 0.7f, Color.green);
        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    */
}
