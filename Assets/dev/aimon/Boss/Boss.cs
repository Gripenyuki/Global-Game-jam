using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public GameObject camB;
    public Animator boss;
    public GameObject player;
    private void Start()
    {
        boss = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBul")
        {
            boss.SetBool("die", true);
            StartCoroutine(nent());
            GameObject cam = GameObject.Find("Main Camera");
            cam.SetActive(false);
            camB.SetActive(true);
            player.SetActive(false);
            Destroy(other.gameObject);
        }
    }

    IEnumerator nent()
    {
        yield return new WaitForSeconds(9.4f);
        SceneManager.LoadScene(3);
    }
}
