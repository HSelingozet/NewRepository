using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Powerup : MonoBehaviour
{
    [Header("Health Settings")]
    public bool healthPowerUp = false;
    public int healthAmount = 1;
    [Header("Ammo Settings")]
    public bool ammoPowerup = false;
    public int ammoAmount = 5;
    [Header("Transform Settings")]
    [SerializeField] private float turnspeed = 1;

    private void Start()
    {
        if(healthPowerUp== true && ammoPowerup == true)
        {
            healthPowerUp = false;
            ammoPowerup = false;
        }
        if (healthPowerUp == true)
        {
            ammoPowerup = false;
        }
        else if (ammoPowerup == true)
        {
            healthPowerUp = false;
        }

    }
    private void Update()
    {
        transform.Rotate(turnspeed, turnspeed, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if(other.gameObject.tag != "Player")
        {
                return;
        }
        if (healthPowerUp)
        {
            other.gameObject.GetComponent<Target>().getHealth += healthAmount;
            //temas eden gameobject'ten, target scriptini getir ve oradaki getHealth'i getir.
        }

        else if (ammoPowerup)
        {
            other.gameObject.GetComponent<Attack>().getAmmoCount += ammoAmount;
        }
        Destroy(gameObject);

    }

}
