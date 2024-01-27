using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletplayer : MonoBehaviour
{
    Animator bullpA;
    Rigidbody2D rb;
    public AudioSource Dead;
    GameObject deadSoundSourceObject;
    [SerializeField] private AudioClip DS;
    private void Start()
    {
        StartCoroutine(bulletlive());
        bullpA = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();  
        deadSoundSourceObject = GameObject.Find("DeadSoundSource");
        Dead = deadSoundSourceObject.GetComponent<AudioSource>();
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
            StartCoroutine(enedie(false," "));
        }
        else if (other.CompareTag("EnemyShoot"))
        {
            EnemyShoot enesh = other.GetComponent<EnemyShoot>();
            enesh.Getene1();
            StartCoroutine(enedie(false, " "));
        }
        else if (other.tag == "Player")
        {
            StartCoroutine(enedie(true,"You'd better not shoot yourself."));
        }

        else if(other.tag == "EneBul")
        {
            StartCoroutine(enedie(false, " "));
        }
        else if (other.tag == "bullboss")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    IEnumerator enedie(bool GOS,string DC)
    {
        bullpA.Play("hit");
        rb.gravityScale = 0;
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.8f);
        Manager.GameOverScreen.SetActive(GOS);
        Manager.DeathCause.text = DC;
        if(GOS)
        {
            Dead.PlayOneShot(DS);
        }
        yield return new WaitForSeconds(0.1f);
        Manager.gameO(GOS);
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    IEnumerator bossf()
    {
        bullpA.Play("hit");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }



}
