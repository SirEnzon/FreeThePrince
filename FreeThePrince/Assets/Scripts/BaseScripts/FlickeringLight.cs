using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    [SerializeField] Light flickerLight;
    [SerializeField] float flickerSpeed;
    [SerializeField] float flickerMax;

    // Update is called once per frame
    void Update()
    {
        LightFLicker();
    }
    void LightFLicker()
    {
       
        flickerLight.intensity = Mathf.PingPong(Time.time * flickerSpeed, flickerMax);
    }
}
