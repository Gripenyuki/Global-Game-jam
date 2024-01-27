using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CutScene2 : MonoBehaviour
{
    private PlayerMovement playMove;
    private PlayerAimWeapon aimWep;

    [SerializeField] private RawImage Screen;
    [SerializeField] private VideoPlayer Clip;
    // Start is called before the first frame update
    
    void Start()
    {
        Screen.enabled = false;
        playMove = FindObjectOfType<PlayerMovement>();
        aimWep = FindObjectOfType<PlayerAimWeapon>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Screen.enabled = true;
            playMove.enabled = false;
            aimWep.enabled = false;
            StartCoroutine(PlayVid());
        }
    }

    IEnumerator PlayVid()
    {
        Clip.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1.0f);
        while(!Clip.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
       Screen.texture = Clip.texture;
       Clip.Play();

       while(Clip.isPlaying)
       {
           yield return null;
       }

       Screen.enabled = false;
       playMove.enabled = true;
       aimWep.enabled = true;
    }
}
