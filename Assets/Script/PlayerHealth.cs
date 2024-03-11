using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float fullHealth;
    public float currentHealth;

    public GameObject PlayerBlood;

    public Slider PlayerHealthSlider;
    public Image damageScreen;
    Color flashColor = new Color(255f, 255f, 255f, 1);
    float flashSpeed = 5f;
    bool damaged = false;

    void Start()
    {
        currentHealth = fullHealth;
        PlayerHealthSlider.maxValue = fullHealth;
        PlayerHealthSlider.value = currentHealth;
    }

    void Update()
    {
        if (damaged)
        {
            damageScreen.color = flashColor;
        }
        else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }
    public void addDamage(float damage)
    {
        currentHealth -= damage;
        PlayerHealthSlider.value = currentHealth;
        damaged = true;
        Instantiate(PlayerBlood, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    public void addHealth(float health)
    {
        currentHealth +=health;
        if(currentHealth > fullHealth) currentHealth = fullHealth;
        PlayerHealthSlider.value = currentHealth;
    }

    public void makeDead()
    {
        Instantiate(PlayerBlood, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        damageScreen.color = flashColor;
        Destroy(gameObject);
    }
}
