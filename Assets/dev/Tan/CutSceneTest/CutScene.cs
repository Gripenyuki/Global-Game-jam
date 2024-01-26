using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    private RectTransform headRectTransform;

    [SerializeField] private float MoveSpeed;
    [SerializeField] private float Deceleration;
    [SerializeField] private Image Base;
    [SerializeField] private Image Head;
    [SerializeField] private GameObject cutScene;
    private Color BaseC;
    private Color HeadC;
    private bool isCutScene;
    // Start is called before the first frame update
    void Start()
    {
        BaseC = Base.color;
        BaseC.a = 0;
        Base.color = BaseC;
        HeadC = Head.color;
        HeadC.a = 0;
        Head.color = HeadC;
        headRectTransform = Head.GetComponent<RectTransform>();
        cutScene.SetActive(false);
    }

    void Update()
    {
        if(isCutScene)
        {
            cutScene.SetActive(true);
            FadeInBase();
        }
        else
        {
            cutScene.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isCutScene = true;
        }
    }

    void FadeInBase()
    {
        BaseC.a += 2 * Time.deltaTime;

        BaseC.a = Mathf.Clamp01(BaseC.a);

        Base.color = BaseC;

        if (BaseC.a >= 1.0f)
        {
            HeadCode();
        }
    }

    void HeadCode()
    {
        Debug.Log("called");
        HeadC.a += 1.0f * Time.deltaTime;
        HeadC.a = Mathf.Clamp01(HeadC.a);
        Head.color = HeadC;

        MoveSpeed += Deceleration * Time.deltaTime;

        headRectTransform.anchoredPosition -= new Vector2(0,MoveSpeed * Time.deltaTime);

        if(headRectTransform.anchoredPosition.y >= 0)
        {
            MoveSpeed = 0;
            Deceleration = 0;
            headRectTransform.anchoredPosition = new Vector2(headRectTransform.anchoredPosition.x, 0);
            isCutScene = false;
        }
    }
}
