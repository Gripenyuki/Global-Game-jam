using System.Collections;
using System.Collections.Generic;
using TMPro;
<<<<<<< Updated upstream
using Unity.VisualScripting;
=======
>>>>>>> Stashed changes
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static GameObject GameOverScreen;
<<<<<<< Updated upstream
    public static GameObject DeathCauseObj;
    public static TMP_Text DeathCause;
    private void Start()
    {
        StartCoroutine(enedie());
    }
    IEnumerator enedie()
    {
        GameOverScreen = GameObject.Find("GameOverScreen");
        DeathCauseObj = GameObject.Find("DeathCause");
        DeathCause = DeathCauseObj.GetComponent<TMP_Text>();
        yield return new WaitForSeconds(0.1f);
        GameOverScreen.SetActive(false);    
=======
    public static GameObject GameOvertext;
    public static TMP_Text DeathCauseTxt;
    private void Start()
    {
        StartCoroutine(GameOverGet());
        Initialize();
    }
    IEnumerator GameOverGet()
    {
        yield return new WaitForSeconds(1f);
        Manager.GameOverScreen.SetActive(false);
    }
    public static void Initialize()
    {
        GameOverScreen = GameObject.Find("GameOverScreen");
        if (GameOverScreen == null)
        {
            Debug.Log("GameOverScreen null");
        }
        GameOvertext = GameObject.Find("DeathCause");
        if (GameOvertext == null)
        {
            Debug.Log("GameOvertext null");
        }
        DeathCauseTxt = GameOvertext.GetComponent<TMP_Text>();
         if (DeathCauseTxt == null)
        {
            Debug.Log("DeathCauseTxt null");
        }

>>>>>>> Stashed changes
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
<<<<<<< Updated upstream

    public static void gameO(bool T) { 
        if (T == true)
        {
            Time.timeScale = 0f;
        }
=======
    public static void Gameover(GameObject go,bool O)
    {
        go.SetActive(O);
>>>>>>> Stashed changes
    }
}
