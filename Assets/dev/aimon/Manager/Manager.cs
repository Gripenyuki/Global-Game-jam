using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static GameObject GameOverScreen;
    public static GameObject DeathCauseObj;
    public static TMP_Text DeathCause;
    private void Start()
    {
        StartCoroutine(enedie());
    }
    IEnumerator enedie()
    {
        GameOverScreen = GameObject.Find("GameOverScreen");
        if (GameOverScreen == null )
        {
            Debug.Log("GameOverScreen null");
        }
        DeathCauseObj = GameObject.Find("DeathCause");
        if (DeathCauseObj == null)
        {
            Debug.Log("DeathCauseObj null");
        }
        DeathCause = DeathCauseObj.GetComponent<TMP_Text>();
        if (DeathCause == null)
        {
            Debug.Log("DeathCause null");
        }
        yield return new WaitForSeconds(0.1f);
        GameOverScreen.SetActive(false);    
    }
    public static void Die(bool l, GameObject ch, Animation cha,float t, MonoBehaviour monoBehaviour , SpriteRenderer sr)
    {
        if(l == false) {
            monoBehaviour.StartCoroutine(Die(cha,t,ch)); 
            sr.color = Color.gray;
        }

    }
    public static IEnumerator Die(Animation ch, float t, GameObject j)
    {
        Debug.Log("5555555");
        yield return new WaitForSeconds(t);
        Destroy(j);
    }

    public static void gameO(bool T) { 
        if (T == true)
        {
            Time.timeScale = 0f;
        }
    }
}
