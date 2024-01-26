using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static void Die(bool l, GameObject ch, Animation cha,float t, MonoBehaviour monoBehaviour , SpriteRenderer sr)
    {
        if(l == false) {
            monoBehaviour.StartCoroutine(Die(cha,t,ch)); 
            sr.color = Color.gray;
        }

    }
    public static IEnumerator Die(Animation ch, float t, GameObject j)
    {
        Debug.Log("5555555");
        yield return new WaitForSeconds(t);
        Destroy(j);
    }
}
