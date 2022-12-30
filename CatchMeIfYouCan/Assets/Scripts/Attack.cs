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
    [SerializeField] private bool isPlayer = false; //attack scriptini kullanan player m� yoksa enemy mi onu anlayacag�z
    
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
       
        
        if (currentFireRate > 0f)//daha s�re dolmad�ysa geri saymaya ba�lar.
        { 
              currentFireRate -= Time.deltaTime;
        }
        //fireRate hesaplamas� enemy ve player icin de gecerli.
        if(isPlayer)//kullan�c� player ise mouse'dan input almal�.
        {
            if (Input.GetMouseButtonDown(0) && currentFireRate <= 0 && ammoCount > 0)

            {

                //if (currentFireRate <= 0) //s�re s�f�rsa ate� edebilir.
                //{
                Fire();

                //}
            }


        }

        /*switch (Input.inputString)//if ile yaz�m� = if(input.inputString == "a")
        {
            case "a": //if ile ayn� �eyi yapar. Oyuncu A'ya bast�ysa bu i�lemi yapar.

                break;

        }*/ //Silahlar aras�nda ge�i� switch case videosu

    }

    public void Fire() //merminin olusmas�n� ve gitmesini saglayan method
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
       
        //olu�an, instantiate edilen mermi bulletClone icinde art�k.
        //o mermi ile ilgili verilere ula�abiliriz.
        bulletClone.GetComponent<Bullet>().owner = gameObject;
        // bu scriptin tak�l� oldugu oyun objesini olu�turdugumuz bullet owner'a yerle�tirmi� oluyoruz.
        // mermiyi kimin ate�ledi�ini bilmi� oluyoruz.
    }
}
