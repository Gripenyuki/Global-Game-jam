using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SuccessTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TimeTxt;

    [SerializeField] private float MaxTime;
    private int TimeToShow;

    // Update is called once per frame
    void Update()
    {
        Elaspe();
        string ShowString = TimeToShow.ToString();
        TimeTxt.text = ShowString;
    }

    void Elaspe()
    {
        MaxTime -= Time.deltaTime;
        TimeToShow = Mathf.RoundToInt(MaxTime);
    }
}
