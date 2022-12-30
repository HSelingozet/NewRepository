using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private Target target;
    public Image healtfill; //referans alýnacak image
    public Image ammoFill;

    // mermi icin playerAttack Script 
    //can icin TargetScript
    private Attack playerAmmo;
    private Target playerHealth;
    private void Awake()
    {
        //tag'i player olan gameobject'i ceker.
        playerAmmo = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
        //Yukarý kodda Attack scripti bulundu ve referans alýndý.
        //Attack scriptinin yerini bildiðimiz için getcomponent kullanarak, Attack'in olduðu yerden Target scriptini bulabiliriz.
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
        //düþman mermisini kendi scriptinde doldurmak için Getclip property olusturmustuk.
        ammoFill.fillAmount =(float) playerAmmo.getAmmoCount / playerAmmo.GetClipsize;
        //mevcut mermi ve max mermi sayýsý bölündü. Fillamount = 0-1f arasý deðer döndürerek dolu ve boþ durumunu ayarlar.

      

    }
}
