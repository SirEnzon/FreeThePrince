using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : Trap
{
    [SerializeField] Transform spikes;
    [SerializeField] float activationDelay;

    Vector3 spikeDefaultPos;
    bool trapIsActivated;

    protected override void OnActivation()
    {
        if (!trapIsActivated)
        {
            StartCoroutine(TrapBehaviour());
        } 
    }

    protected override IEnumerator TrapBehaviour()
    {
        Debug.Log("HDKSHKSHKSD");
        float timer = activationDelay;
        spikeDefaultPos = spikes.position;
        trapIsActivated = true;
        while(timer >= 0)
        {
            trapIsActivated = true;
            timer -= Time.deltaTime;
            spikes.position = Vector3.Lerp(spikes.position, transform.position + new Vector3(0,1f,0), Time.deltaTime );
            yield return new WaitForEndOfFrame();
        }
        trapIsActivated = false;
        spikes.position = spikeDefaultPos;
    }
    void  OnTriggerEnter(Collider other)
    {
        Debug.Log("heyIamActivatedlol");
        OnActivation();
    }
    void OnTriggerExit(Collider other)
    {
        StopCoroutine(TrapBehaviour());
    }
}
