using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed=10;
    public GameObject owner; //merminin kimden çýktýgýný belirtiyoruz.
    private void Update()
    {
      transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Target>() == false) //temas edilen objede target scripti yoksa 
        {
            Destroy(gameObject);
        }
      
    }
}
