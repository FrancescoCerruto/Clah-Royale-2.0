using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//vita di torre e veicoli

public class Health : MonoBehaviour, Killed<float>
{
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float health;
    protected bool dead = false;

    protected virtual void OnEnable()
    {
        health = maxHealth;
    }

    public virtual void Hit(float damage)
    {
        health -= damage;
        Kill();
    }

    public virtual void Kill()
    { }

    public float GetHealth()
    {
        return health;
    }
}