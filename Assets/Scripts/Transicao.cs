using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transicao : MonoBehaviour
{
    public Image TransitionImage;
    public float vel;
    public bool finished;

    Color transparent = new Color(0, 0, 0, 0);

    void Start()
    {
        StartTransicao(Color.black, transparent);
    }

    public void StartTransicao(Color Start, Color End)
    {
        finished = false;
        StartCoroutine(DoTransition(Start, End));
    }


    IEnumerator DoTransition(Color Start, Color End)
    {
        float t = 0;

        while (true)
        {
            t = t + Time.unscaledDeltaTime * vel;
            TransitionImage.color = Color.Lerp(Start, End, t);
            if (t >= 1)
            {
                break;
            }
            yield return new WaitForEndOfFrame();
        }

        finished = true;
    }
}