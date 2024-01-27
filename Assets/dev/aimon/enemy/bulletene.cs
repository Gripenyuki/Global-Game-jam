using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class bulletene : MonoBehaviour
{
<<<<<<< Updated upstream
    Animator bullB;
=======
>>>>>>> Stashed changes
    Rigidbody2D rb;
    private void Start()
    {
        StartCoroutine(bulletlive());
<<<<<<< Updated upstream
        rb = gameObject.GetComponent<Rigidbody2D>();
        bullB = GetComponent<Animator>();
=======
        rb = GetComponent<Rigidbody2D>();
>>>>>>> Stashed changes
    }


    IEnumerator bulletlive()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject GameOverScreen = GameObject.Find("GameOverScreen");
        GameObject GameOvertext = GameObject.Find("DeathCause");
        if (other.tag == "G")
        {
            StartCoroutine(bullene(false, " "));
        }
        if (other.tag == "Player")
        {
<<<<<<< Updated upstream
            StartCoroutine(bullene(true, "Why don't you dodge this!!"));
        }
    }
    IEnumerator bullene(bool GOS, string DC)
    {
        rb.gravityScale = 0;
        rb.velocity = Vector3.zero;
        bullB.Play("hitplay");
        yield return new WaitForSeconds(0.8f);
        Manager.GameOverScreen.SetActive(GOS);
        Manager.DeathCause.text = DC;
        yield return new WaitForSeconds(0.1f);
        Manager.gameO(GOS);
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
=======
            GameOverScreen.SetActive(true);
            Playex("Why don't you dodge this!!", true);
        }
    }
    IEnumerator Playex(string A, bool GO)
    {
        yield return new WaitForSeconds(0.5f);
        //rb.isKinematic = true;
        Manager.Gameover(Manager.GameOverScreen, GO);
        Manager.DeathCauseTxt.text = A;
        Destroy(gameObject);

>>>>>>> Stashed changes
    }
}
