using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject levelFinishParent;
    private Target playerHealth;
   
    

    
    
    void Start()
    {
        
    }

  
    void Update()
    {
        int enemyCount = FindObjectsOfType<Enemy>().Length;
       




        //sahnede Enemy tag'inde olan objeleri getirir.
        //update fonk. icinde yazdýk cünkü düsman öldükce sayý güncellensin istiyoruz.
        if (enemyCount <= 0)
        {
            levelFinishParent.gameObject.SetActive(true);
           
        }
        else
        {
            levelFinishParent.gameObject.SetActive(false);
            
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
