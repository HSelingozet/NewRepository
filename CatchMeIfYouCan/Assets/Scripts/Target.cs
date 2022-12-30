using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Target : MonoBehaviour
{
    [SerializeField] private int maxHealth =2;
  
    private int currentHealth;
   
  


    public int GetMaxHealth
    {
        get { return maxHealth; }
    }
    public int getHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
            if(currentHealth > maxHealth)
            {
                currentHealth = maxHealth;

            }
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
 
    }

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Z))
        {
            currentHealth--;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.gameObject.GetComponent<Bullet>();
        //Bullet deðiþkenine, Bullet scripti olan objeyi aldýk
        //mermiyi referans aldýk.!!!!!
        
        if(bullet)
        {
           /* if (bullet && bullet.owner != gameObject) //mermiye sahipsek ve mermiye sahip olan kiþi gameobject deðilse.
            {
                currentHealth--;
            }*/
            currentHealth--;

            if (currentHealth <= 0)
            {
                Die();
            }
            Destroy(other.gameObject);
        }
    }
    public void Die()
    {
       
        Destroy(gameObject);
      



    }
}
