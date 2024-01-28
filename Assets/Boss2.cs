using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2 : MonoBehaviour
{
    public GameObject player;
    public GameObject end;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBul")
        {
            end.SetActive(true);
            player.SetActive(false);
        }
    }

    IEnumerator nent()
    {
        yield return new WaitForSeconds(9.4f);
        LoadSceneByNumber(2);
    }
    public void LoadSceneByNumber(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
