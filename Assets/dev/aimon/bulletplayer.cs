using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletplayer : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(bulletlive());
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
            Destroy(gameObject);
        }
        else if (other.CompareTag("EnemyShoot"))
        {
            EnemyShoot enesh = other.GetComponent<EnemyShoot>();
            enesh.Getene1();
            Destroy(gameObject);
        }
        else if (other.tag == "Player")
        {
            Debug.Log("hitplayer");
        }

        else if(other.tag == "EneBul")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

    }

   
}
