using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cre : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cred());
    }
    IEnumerator cred()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(0);
    }
}
