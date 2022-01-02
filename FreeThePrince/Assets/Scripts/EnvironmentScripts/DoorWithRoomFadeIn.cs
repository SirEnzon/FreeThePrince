using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithRoomFadeIn : MonoBehaviour
{
    [SerializeField] GameObject roomToFadeIn;
    Renderer roomToFadeInRenderer;
    Color fogColor;
    Color fogColor2;
    bool fadeStarted = true;

    private void Awake()
    {
        roomToFadeInRenderer = roomToFadeIn.GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && fadeStarted)
        {
            StartCoroutine(FadeOutRoom());
        }
    }
    IEnumerator FadeOutRoom()
    {
        fogColor = roomToFadeInRenderer.material.GetColor("FogColor");
        fogColor2 = roomToFadeInRenderer.material.GetColor("FogColor2");
        Debug.Log("HELLO");
        float fadeOutTime = 1;
        while(fadeOutTime >= 0 && fadeStarted)
        {
            fadeOutTime -= Time.deltaTime;
            fogColor = Color.Lerp(fogColor, Color.clear, Time.deltaTime);
            fogColor2 = Color.Lerp(fogColor2, Color.clear, Time.deltaTime);
            roomToFadeInRenderer.material.SetColor("FogColor", fogColor);
            roomToFadeInRenderer.material.SetColor("FogColor2", fogColor2);

            yield return new WaitForEndOfFrame();
        }
        roomToFadeIn.SetActive(false);
        fadeStarted = false;
    }
}
