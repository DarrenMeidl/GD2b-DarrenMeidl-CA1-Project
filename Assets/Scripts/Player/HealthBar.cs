using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//This code for the Health Bar came from tutorial, link: https://www.youtube.com/watch?v=mi_SP0sippI&ab_channel=CatTrapStudios
//AND from this page: https://discussions.unity.com/t/my-health-bars-image-fillamount-doesnt-change/153541/4
public class HealthBar : MonoBehaviour
{
    //Maximum & Current health in private fields & reference to Image
    private float maxHealth;
    private float health; 
    private Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>(); //Grabs Image component (our health bar)
        maxHealth = PlayerHealth.playerMaxHealth; //maxHealth will equal whatever the player's maximum health is set to in PlayerHealth script
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        health = PlayerHealth.currentPlayerHealth; //health is set to whatever the player's current health is set to in PlayerHealth script
        healthBar.fillAmount = (health/maxHealth); //Fills in the health bar image by a fraction of current health over max health
    }
}
