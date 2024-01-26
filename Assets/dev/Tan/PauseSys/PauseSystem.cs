using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    private PlayerAimWeapon aiming;

    private bool isPause;

    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
        aiming = FindObjectOfType<PlayerAimWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    void Pause()
    {
        isPause = !isPause;

        if(isPause)
        {
            Time.timeScale = 0;
            aiming.enabled = false;
        }
        else
        {
            Time.timeScale = 1;
            aiming.enabled = true;
        }
    }
}
