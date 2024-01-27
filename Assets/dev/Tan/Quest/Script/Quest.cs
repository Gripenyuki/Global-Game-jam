using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] GameObject WallToBreak;
    [SerializeField] float WallHealth;
    private bool inRange;
    private float WallHeight;

    // Start is called before the first frame update
    void Start()
    {
        WallHeight = WallToBreak.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange)
        {
            if(Input.GetKeyDown(KeyCode.I))
            {
                WallHealth -= 1;
            }
        }

        if(WallHealth <= 0)
        {
            Destroy(WallToBreak.gameObject);
        }

        WallBreakDown();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    void WallBreakDown()
    {
        WallToBreak.transform.localScale = new Vector3(WallToBreak.transform.localScale.x , WallHealth/10 * WallHeight , 0);
    }
}
