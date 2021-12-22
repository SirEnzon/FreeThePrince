using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    static public  SpawnManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void SpawnProjectiles(float delayBetweenShots, float numberOfProjectiles, GameObject projectile,Transform spawnPos)
    {
        StartCoroutine(SpawnNumberOfProjectiles(delayBetweenShots, numberOfProjectiles, projectile,spawnPos));
    }
    public IEnumerator SpawnNumberOfProjectiles(float delayBetweenShots, float numberOfProjectiles, GameObject projectile,Transform spawnPos)
    {
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            Instantiate(projectile, spawnPos.position, spawnPos.rotation);
            yield return new WaitForSeconds(delayBetweenShots);
        }
    }
}
