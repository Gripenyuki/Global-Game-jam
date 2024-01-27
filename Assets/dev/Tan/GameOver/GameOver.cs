using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static void test(Collision2D other)
    {
        GameObject GameOverScreen = GameObject.Find("GameOverScreen");
        GameObject GameOvertext = GameObject.Find("DeathCause");
        TMP_Text DeathCauseTxt = GameOvertext.GetComponent<TMP_Text>();
        if (other.gameObject.CompareTag("Player"))
        {
            GameOverScreen.SetActive(true);
              DeathCauseTxt.text = "You'd better not shoot yourself.";
        }

        if(other.gameObject.CompareTag("EneBul"))
        {
            GameOverScreen.SetActive(true);
            DeathCauseTxt.text = "Why don't you dodge this!!";
        }

<<<<<<< Updated upstream
        if(other.gameObject.CompareTag("Enemy"))
        {
            GameOverScreen.SetActive(true);
            DeathCauseTxt.text = "You got smashed to death by a lil cutie turtle";
        }
=======
>>>>>>> Stashed changes
    }
}
