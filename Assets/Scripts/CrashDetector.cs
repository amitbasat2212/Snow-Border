using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    // Start is called before the first frame update
    CircleCollider2D playerHead;
    [SerializeField] float Delay=0.5f;

    bool Soundonce=false;
    
    [SerializeField] AudioClip crashSounds;
    [SerializeField] ParticleSystem crashPlayer;
    void Start()
    {
        playerHead = GetComponent<CircleCollider2D>();
    }
     void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("ground") && playerHead.IsTouching(other.collider) &&Soundonce==false )
        {
             Soundonce=true;
             FindObjectOfType<PlayerCOntroller>().DisableControllor();
           // Debug.Log("I hit my friggin Head");
             crashPlayer.Play();
             GetComponent<AudioSource>().PlayOneShot(crashSounds);
             Invoke("LoadSecene",Delay);
           
            

        }
    }

    public void LoadSecene(){
        SceneManager.LoadScene(0);
    }
}
