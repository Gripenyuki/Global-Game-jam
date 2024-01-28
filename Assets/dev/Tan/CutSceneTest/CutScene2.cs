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
    [SerializeField] private AudioSource Sound;
    // Start is called before the first frame update
    
    void Start()
    {
        playMove = FindObjectOfType<PlayerMovement>();
        aimWep = FindObjectOfType<PlayerAimWeapon>();
        playMove.enabled = false;
        Screen.enabled = true;
        aimWep.enabled = false;
        Time.timeScale = 0;
        StartCoroutine(PlayVid());
    }
    IEnumerator PlayVid()
    {
        Clip.Prepare();
        Sound.Play();
        WaitForSeconds waitForSeconds = new WaitForSeconds(3.0f);
        while(!Clip.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
       Screen.texture = Clip.texture;

        float videoAspect = (float)Clip.width / Clip.height;
        Screen.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.rectTransform.rect.height * videoAspect);

        Clip.Play();

       while(Clip.isPlaying)
       {
           yield return null;
       }

        Screen.enabled = false;
       playMove.enabled = true;
       aimWep.enabled = true;
        Time.timeScale = 1;
    }
}
