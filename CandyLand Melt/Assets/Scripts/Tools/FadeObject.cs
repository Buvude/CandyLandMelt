using System.Collections;
using UnityEngine;

public class FadeObject : MonoBehaviour
{
    public GameObject fadingObject;
    [SerializeField] float fadeSpeed;
    private Coroutine lastCoroutine;

    public void FadeSprite(bool appearing)
    {
        if (appearing)
        {
            if (lastCoroutine != null)
                StopCoroutine(lastCoroutine);
            lastCoroutine = StartCoroutine(FadeProcess(true));
        }
        else
        {
            if (lastCoroutine != null)
                StopCoroutine(lastCoroutine);
            lastCoroutine = StartCoroutine(FadeProcess(false));
        }
    }
    public void FadeCanvas(bool appearing)
    {
        if (appearing)
        {
            StopCoroutine(FadeCanvasProcess(false));
            StartCoroutine(FadeCanvasProcess(true));
        }
        else
        {
            StopCoroutine(FadeCanvasProcess(true));
            StartCoroutine(FadeCanvasProcess(false));
        }
    }
    private IEnumerator FadeProcess(bool fadeToAppear = true) //needs to be called with  StartCoroutine(FadeProcess());
    {
        Color objectColor = fadingObject.GetComponent<SpriteRenderer>().color;
        float fadeAmount;

        if(fadeToAppear)
        {
            while (fadingObject.GetComponent<SpriteRenderer>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                fadingObject.GetComponent<SpriteRenderer>().color = objectColor;
                yield return null; //while ends when the object is opaque
            }
        }
        else
        {
            while (fadingObject.GetComponent<SpriteRenderer>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                fadingObject.GetComponent<SpriteRenderer>().color = objectColor;
                yield return null; //while ends when the object is invisible
            }

        }
    }

    private IEnumerator FadeCanvasProcess(bool fadeToAppear = true) //needs to be called with  StartCoroutine(FadeCanvasProcess());
    {
        float objectAlpha = fadingObject.GetComponent<CanvasGroup>().alpha;
        float fadeAmount;
        float fadeSpeedDivided10 = fadeSpeed / 10;
        if (fadeToAppear)
        {
            while (fadingObject.GetComponent<CanvasGroup>().alpha < 1)
            {
                objectAlpha = fadingObject.GetComponent<CanvasGroup>().alpha;
                fadeAmount = objectAlpha + (fadeSpeedDivided10 * Time.deltaTime);
                fadingObject.GetComponent<CanvasGroup>().alpha = fadeAmount;
                yield return null; //while ends when the object is opaque
            }
        }
        /*
        else
        {
            while (fadingObject.GetComponent<SpriteRenderer>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                fadingObject.GetComponent<SpriteRenderer>().color = objectColor;
                yield return null; //while ends when the object is invisible
            }

        }
        */
    }
}
