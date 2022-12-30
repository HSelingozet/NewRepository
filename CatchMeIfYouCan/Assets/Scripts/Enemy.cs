using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using Unity.VisualScripting;
using UnityEngine;
//----Enemy ate� etme olay� bu scriptte------//
//----Attack scriptini referans almam�z gerek----//

public class Enemy : MonoBehaviour
{

    [SerializeField] private Transform[] movePoints;
    private float speed = 5f;
    private bool canMoveRight=true;
    [SerializeField] private float shootRange = 10f; //at�� menzili
    [SerializeField] private LayerMask shootLayer;
    [SerializeField] private Transform aimTransform;
    private Attack attack;
    private bool isReloaded = false;
   

    private void Start()
    {
       attack = GetComponent<Attack>();
    }

    private bool Aim()
    {
        bool hit = Physics.Raycast(aimTransform.position, transform.forward, shootRange, shootLayer);
        //transformun �n� neresiyse oraya dogru git = transform.forward
        Debug.DrawRay(aimTransform.position, transform.forward * shootRange, Color.blue);
        return hit;
    }
   

    private void Update()
    {
        EnemyAttack();
      

        CheckCanMoveRight();
        //nereye gidece�imiz sorusuna cvp buluyoruz
        MoveTowards();
        //cevaba g�re hareket ediyoruz.
        Aim();
    }

    private void Reload()
    {
        attack.getAmmoCount = attack.GetClipsize;
        isReloaded = false;
    }

   private void EnemyAttack() //d�sman�n mermi ateslemesi
    {
        if(attack.getAmmoCount <=0 && isReloaded == false)
        {
            Invoke("Reload", 5f);
            isReloaded = true;
            
        }
        if (attack.GetCurrentFareRate <= 0 && attack.getAmmoCount > 0 && Aim())
        {
            attack.Fire();
        }
    }
    //saga gidiyorsa sola, sola gidiyorsa saga gidecek

    private void MoveTowards()
    {
        if(canMoveRight)
        {
            transform.position = Vector3.MoveTowards(transform.position,movePoints[1].position, speed * Time.deltaTime);
            LookAtTheTarget(movePoints[1].position);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,movePoints[0].position, speed * Time.deltaTime);
            LookAtTheTarget(movePoints[0].position);
        }
    }

    private void CheckCanMoveRight() //saga m� gidiyor sola m�. sola yakla�t�ysa sola gidiyor saga yaklast�ysa saga gidiyor.
    {
        if (Vector3.Distance(transform.position, movePoints[0].position) <= 0.1f)
        {
            canMoveRight = true;

        }
        else if (Vector3.Distance(transform.position, movePoints[1].position) <= 0.1f)
        {
            canMoveRight = false;
        }

    }
    private void LookAtTheTarget(Vector3 newTarget)
    {
       // Vector3 newLookPosition = new Vector3(newTarget.x, transform.position.y, newTarget.z);
        Quaternion targetRotation = Quaternion.LookRotation(newTarget - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.deltaTime);

    }
   
}
