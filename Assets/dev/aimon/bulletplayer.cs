using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class bulletplayer : MonoBehaviour
{
<<<<<<< Updated upstream
    Animator bullpA;
    Rigidbody2D rb;
    private void Start()
    {
        StartCoroutine(bulletlive());
        bullpA = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();        
=======
    Animator bullA;
    Rigidbody2D rb;
    void Start()
    {
        StartCoroutine(bulletlive());
        bullA = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
>>>>>>> Stashed changes
    }
    IEnumerator bulletlive()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        //Check to see if the tag on the collider is equal to Enemy
        if (other.CompareTag("Enemy"))
        {
            enemy ene = other.GetComponent<enemy>();
            ene.Getene();
<<<<<<< Updated upstream
            StartCoroutine(enedie(false," "));
=======
            StartCoroutine(Playex("", false));
>>>>>>> Stashed changes
        }
        else if (other.CompareTag("EnemyShoot"))
        {
            EnemyShoot enesh = other.GetComponent<EnemyShoot>();
            enesh.Getene1();
<<<<<<< Updated upstream
            StartCoroutine(enedie(false, " "));
        }
        else if (other.tag == "Player")
        {
            StartCoroutine(enedie(true,"You'd better not shoot yourself."));
=======
            StartCoroutine(Playex("", false));
        }
        else if (other.tag == "Player")
        {
            StartCoroutine(Playex("You'd better not shoot yourself.",true));
>>>>>>> Stashed changes
        }

        else if(other.tag == "EneBul")
        {
<<<<<<< Updated upstream
            StartCoroutine(enedie(false, " "));
=======
            StartCoroutine(Playex("", false));
            Destroy(other.gameObject);
>>>>>>> Stashed changes
        }
    }
    IEnumerator Playex(string A ,bool GO)
    {
        bullA.Play("hit");
        rb.velocity = Vector3.zero;
        rb.gravityScale = 0;
        yield return new WaitForSeconds(0.9f);
        Manager.Gameover(Manager.GameOverScreen, GO);
        Manager.DeathCauseTxt.text = A;
        Destroy(gameObject);

    }

<<<<<<< Updated upstream
    IEnumerator enedie(bool GOS,string DC)
    {
        bullpA.Play("hit");
        rb.gravityScale = 0;
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.8f);
        Manager.GameOverScreen.SetActive(GOS);
        Manager.DeathCause.text = DC;
        yield return new WaitForSeconds(0.1f);
        Manager.gameO(GOS);
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }


=======
>>>>>>> Stashed changes
}
