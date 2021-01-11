﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {
    [SerializeField] private int health = 11;
    [SerializeField] private int currentHealth = 11;

    [SerializeField] private Sprite[] hearts;
    [SerializeField] private Image fullhearts;

    private void Start()
    {
        currentHealth = health;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            DamageHearts(1);
        }else if(Input.GetKeyDown(KeyCode.C))
        {
            DamageHearts(2);
        }else if(Input.GetKeyDown(KeyCode.X))
        {
            HealHearts(1);
        }else if(Input.GetKeyDown(KeyCode.V))
        {
            HealHearts(2);
        }

        if(currentHealth <= 0)
        {
            Time.timeScale = 0f;
            //die behavior here
        }
    }

    private void DamageHearts(int dmg)
    {
        //give dmg int for double damage or falldamage?
        if (currentHealth >= 0 )
        {
            currentHealth = currentHealth - dmg;
            fullhearts.sprite = hearts[currentHealth + 1];
        }
    }

    private void HealHearts(int heal)
    {
        if(currentHealth < 11)
        {
            currentHealth = currentHealth + heal;
            fullhearts.sprite = hearts[currentHealth+1];
        }
    }
}