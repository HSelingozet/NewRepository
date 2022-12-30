using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject ammo;
    [SerializeField] private Transform fireTransform;
    //private float attackSpeed = 1.0f;
    [SerializeField] private float fireRate = 5.0f;
    private float currentFireRate = 0f;
    private int ammoCount;
    private int maxAmmoCount = 10;
    [SerializeField] private bool isPlayer = false; //attack scriptini kullanan player mý yoksa enemy mi onu anlayacagýz
    
    public int GetClipsize //maxAmmo cekmek icin.
    {
        get
        {
            return maxAmmoCount;
        }
    }

    public int getAmmoCount
    {
        get
        {
            return ammoCount;
        }
        set
        {
            ammoCount = value;   
            if(ammoCount > maxAmmoCount)
            {
                maxAmmoCount = ammoCount;
            }
        }
    }

    public float GetCurrentFareRate
    {
        get
        {
            return currentFireRate;
        }
        set
        {
            value = currentFireRate;
        }
    }
    private void Start()
    {
        ammoCount = maxAmmoCount;
    }
    private void Update()
    {
       
        
        if (currentFireRate > 0f)//daha süre dolmadýysa geri saymaya baþlar.
        { 
              currentFireRate -= Time.deltaTime;
        }
        //fireRate hesaplamasý enemy ve player icin de gecerli.
        if(isPlayer)//kullanýcý player ise mouse'dan input almalý.
        {
            if (Input.GetMouseButtonDown(0) && currentFireRate <= 0 && ammoCount > 0)

            {

                //if (currentFireRate <= 0) //süre sýfýrsa ateþ edebilir.
                //{
                Fire();

                //}
            }


        }

        /*switch (Input.inputString)//if ile yazýmý = if(input.inputString == "a")
        {
            case "a": //if ile ayný þeyi yapar. Oyuncu A'ya bastýysa bu iþlemi yapar.

                break;

        }*/ //Silahlar arasýnda geçiþ switch case videosu

    }

    public void Fire() //merminin olusmasýný ve gitmesini saglayan method
    {
        float differences = 180 - transform.eulerAngles.y;
        float targetRotation = -90;
        if (differences >= 90f)
        {
             targetRotation = -90f;
        }
        else if(differences < 90f)
        {
            targetRotation = 90f;
        }
        ammoCount--;
        currentFireRate = fireRate;

        GameObject bulletClone = Instantiate(ammo, fireTransform.position, Quaternion.Euler(0f,0f,targetRotation)); 
       
        //oluþan, instantiate edilen mermi bulletClone icinde artýk.
        //o mermi ile ilgili verilere ulaþabiliriz.
        bulletClone.GetComponent<Bullet>().owner = gameObject;
        // bu scriptin takýlý oldugu oyun objesini oluþturdugumuz bullet owner'a yerleþtirmiþ oluyoruz.
        // mermiyi kimin ateþlediðini bilmiþ oluyoruz.
    }
}
