using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private Target target;
    public Image healtfill; //referans al�nacak image
    public Image ammoFill;

    // mermi icin playerAttack Script 
    //can icin TargetScript
    private Attack playerAmmo;
    private Target playerHealth;
    private void Awake()
    {
        //tag'i player olan gameobject'i ceker.
        playerAmmo = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
        //Yukar� kodda Attack scripti bulundu ve referans al�nd�.
        //Attack scriptinin yerini bildi�imiz i�in getcomponent kullanarak, Attack'in oldu�u yerden Target scriptini bulabiliriz.
        playerHealth = playerAmmo.GetComponent<Target>();
    }


    void Update()
    {
        UpdateHealthFill();
        UpdateAmmoFill();
    }

    private void UpdateHealthFill()
    {
        healtfill.fillAmount = (float)playerHealth.getHealth / playerHealth.GetMaxHealth;

    }
    private void UpdateAmmoFill()
    {
        //d��man mermisini kendi scriptinde doldurmak i�in Getclip property olusturmustuk.
        ammoFill.fillAmount =(float) playerAmmo.getAmmoCount / playerAmmo.GetClipsize;
        //mevcut mermi ve max mermi say�s� b�l�nd�. Fillamount = 0-1f aras� de�er d�nd�rerek dolu ve bo� durumunu ayarlar.

      

    }
}
