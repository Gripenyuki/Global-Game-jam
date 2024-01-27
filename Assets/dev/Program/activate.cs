using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate : MonoBehaviour
{
   public GameObject gameObject;
    void Start()
    {
        gameObject.SetActive(true);
    }

}
