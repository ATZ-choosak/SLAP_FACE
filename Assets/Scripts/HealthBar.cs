using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthSlider;
    public Image easeHealthSlider;
    public float maxHealth = 100f;
    public float health;
    private float lerpSpeed = 0.05f;
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        healthSlider.fillAmount = health / maxHealth;
        easeHealthSlider.fillAmount = Mathf.Lerp(easeHealthSlider.fillAmount , healthSlider.fillAmount , lerpSpeed);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
