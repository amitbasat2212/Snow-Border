using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinsihLine : MonoBehaviour
{

    [SerializeField] float Delay =2f;
    [SerializeField] ParticleSystem finishLine;
    // Start is called before the first frame update
   void OnTriggerEnter2D(Collider2D other) {

       if(other.tag=="Player") {

        //Debug.Log("you finished");
            finishLine.Play();
            Invoke("reloadScene",Delay);
            GetComponent<AudioSource>().Play();
       }    
   }

   void reloadScene(){
        SceneManager.LoadScene(0);
   }


}
