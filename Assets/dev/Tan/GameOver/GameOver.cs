using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private TextMeshProUGUI DeathCauseTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("PlayerBul"))
        {
            GameOverScreen.SetActive(true);
            DeathCauseTxt.text = "You'd better not shoot yourself.";
        }

        if(other.gameObject.CompareTag("EneBul"))
        {
            GameOverScreen.SetActive(true);
            DeathCauseTxt.text = "Why don't you dodge this!!";
        }

        if(other.gameObject.CompareTag("Enemy"))
        {
            GameOverScreen.SetActive(true);
            DeathCauseTxt.text = "You got smashed to death by a lil cutie turtle";
        }
    }
}
