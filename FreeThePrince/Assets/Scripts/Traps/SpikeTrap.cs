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
        damageDelay = false;
        float timer = activationDelay;
        spikeDefaultPos = spikes.position;
       
        while(activationDelay >= 0)
        {
            trapIsActivated = true;
            activationDelay -= Time.deltaTime;
            spikes.position = Vector3.Lerp(spikes.position, spikes.position + new Vector3(0,0.4f,0), Time.deltaTime );
            yield return new WaitForEndOfFrame();
        }
        trapIsActivated = false;
        spikes.position = spikeDefaultPos;
        activationDelay = 2;

    }
    void  OnTriggerEnter(Collider other)
    {
        OnActivation();
    }
    void OnTriggerExit(Collider other)
    {
        StopCoroutine(TrapBehaviour());
    }
}
