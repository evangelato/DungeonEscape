using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canDamage = true;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.name);
        IDamageable hit = other.GetComponent<IDamageable>();
        if (hit != null && _canDamage)
        {
            hit.Damage();
            _canDamage = false;
            StartCoroutine(CooldownAttackRoutine());
        }
    }

    IEnumerator CooldownAttackRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}
