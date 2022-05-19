
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionsHandler : MonoBehaviour
{
  private AudioSource audioSource;
  [SerializeField] private AudioClip crashClip;
  [SerializeField] private AudioClip successClip;
 [Tooltip ("In Seconds")][SerializeField] private float levelloadDelay = 1f;
 private bool isTransitioning =  false;
 private void Start() {
   audioSource = GetComponent<AudioSource>();
 }
   private void OnCollisionEnter(Collision other)   
   {
     if(isTransitioning) return;
     switch (other.gameObject.tag)
     {
         case "Friendly":
            print("ayo this is a friend");
            break;
            case "Finish":
                Finish();
                LoadNextScene();
                break;
            default:

                Crash();
                break;
        }  
   }

    private void Finish()
    {   isTransitioning = true;
    GetComponent<PlayerController>().enabled = false;
        if(!successClip) audioSource.PlayOneShot (successClip);
        Invoke(nameof(LoadNextScene), levelloadDelay);
        
    }

    private void Crash()
    { isTransitioning = true;
      GetComponent<PlayerController>().enabled = false;
        if(!crashClip) audioSource.PlayOneShot (crashClip);
        Invoke(nameof(ReloadScene), levelloadDelay);
    }

    private void LoadNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex; 
       sceneIndex ++;
        if(sceneIndex == SceneManager.sceneCountInBuildSettings) sceneIndex = 0;
        
          
        
        SceneManager.LoadScene(sceneIndex++); 
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
