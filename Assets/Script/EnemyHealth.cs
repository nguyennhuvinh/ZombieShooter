using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float enemyMaxHealth;
    public float damageModifier;
    public GameObject damageParticles;
    public bool drops;
    public GameObject drop;
    public bool canBurn;
    public float burnTime;
    public GameObject burnEffects;

    bool onFire;
    float nextBurn;
    float burnInterval = 1f;
    float endBurn;

    float currentHealth;
    public Slider enemyHealthIndicator;

    void Start()
    {
        currentHealth = enemyMaxHealth;
        enemyHealthIndicator.maxValue = enemyMaxHealth;
        enemyHealthIndicator.value = currentHealth;
    }

   

    public void addDamage(float damage)
    {
        enemyHealthIndicator.gameObject.SetActive(true);
        damage = damage * damageModifier;
        if (damage <= 0f) return;
        currentHealth -= damage;
        enemyHealthIndicator.value = currentHealth;
        if (currentHealth <= 0) makeDead();
    }

    public void damgeFX(Vector3 point, Vector3 rotation)
    {
        Instantiate(damageParticles, point, Quaternion.Euler(rotation));
    }

    //public void addFire()
    //{
    //    if (!canBurn) return;
    //    onFire = true;
    //    burnEffects.SetActive(true);
    //    endBurn = Time.time + burnTime;
    //    nextBurn = Time.time + burnInterval;
    //}

    public void makeDead()
    {
        Destroy(gameObject.transform.root.gameObject);
        if (drops) Instantiate(drop, transform.position + Vector3.up * 1f, Quaternion.identity);
    }
}
