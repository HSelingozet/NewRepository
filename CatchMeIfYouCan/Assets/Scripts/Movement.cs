using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 50.0f;
    [SerializeField] private float jumpPower = 50.0f;
    [SerializeField] private Transform[] rayCastStartPoints;
    [SerializeField] private float turnSpeed = 15f;
   

    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        TakeInput();
        
    }

    private void TakeInput()
    {
        if (Input.GetKey(KeyCode.Space) && onGroundCheck())
        {
            _rb.velocity = new Vector3(_rb.velocity.x, (jumpPower * 100) * Time.deltaTime, 0f);
        }
        else if (Input.GetKey("a"))
        {
            _rb.velocity = new Vector3(Mathf.Clamp((-speed * 100 )*Time.deltaTime, -15f,0f), _rb.velocity.y, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, -90f, 0f), turnSpeed * Time.deltaTime);
        }

        else if (Input.GetKey("d"))
        {
            _rb.velocity = new Vector3(Mathf.Clamp((speed * 100 ) * Time.deltaTime,0f,15f), _rb.velocity.y, 0f);
            
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 90f, 0f), turnSpeed * Time.deltaTime);

        }
       
        else
        {
            _rb.velocity = new Vector3(0f, _rb.velocity.y, 0f);
           // _rb.velocity = new Vector3(0f, 0f, 0f);
        }  

    }
    //ýþýn yeri algýlýyorsa zýplamasýný istiyoruz. True ya da false dödürmesi gerekiyor.
    private bool onGroundCheck()
    {
        bool hit= false;
        for(int i = 0;i < rayCastStartPoints.Length;i++)
        {
            hit = Physics.Raycast(rayCastStartPoints[i].position, Vector3.down, 0.50f);
            Debug.DrawRay(rayCastStartPoints[i].position, Vector3.down * 0.50f, Color.red); // ýþýnýný ekranda görünmesini saðlar.
        }
       
      
        if(hit)
        {
            return true;
        }
        else
        {
            return false;
        }

    }


}
