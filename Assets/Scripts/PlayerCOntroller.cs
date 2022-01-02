using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCOntroller : MonoBehaviour
{
        Rigidbody2D rb2d;
        [SerializeField] float torqamount = 1f;
        [SerializeField] float boostSpped=40f;
        [SerializeField] float baseSpeed = 30f; 
        SurfaceEffector2D surfaceEffector2D; 

        bool canMove = true;
    
    // Start is called before the first frame update
    void Start()
    {
       surfaceEffector2D=FindObjectOfType<SurfaceEffector2D>();     
       rb2d= GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){     
        rotetePlayer();
        RespondtoBoost();
        }
    }

    public void DisableControllor(){
        canMove=false;
    }

     void RespondtoBoost()
    {   
        if(Input.GetKey(KeyCode.UpArrow)){
            surfaceEffector2D.speed=boostSpped;
        }else{
            surfaceEffector2D.speed=baseSpeed;
        }
        
    }

     void rotetePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqamount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqamount);
        }
    }
}
