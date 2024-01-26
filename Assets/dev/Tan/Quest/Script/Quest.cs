using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] GameObject WallToBreak;
    [SerializeField] float WallHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            WallHealth -= 1;
        }

        if(WallHealth<=0)
        {
            Destroy(WallToBreak.gameObject);
        }
    }
}
