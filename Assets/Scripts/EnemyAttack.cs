using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackTime;
    private Animator anim;
    public int health;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(attackTime);
        anim.SetTrigger("isAttack");
        StartCoroutine(Timer());
    }
}
