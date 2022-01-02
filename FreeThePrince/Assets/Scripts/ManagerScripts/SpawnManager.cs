using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnManager : MonoBehaviour
{ 
    //[SerializeField] GameObject arrow;
    static public  SpawnManager instance;
    //public ObjectPool<GameObject> arrowProjectiles;
    
    private void Awake()
    { 
       
        if(instance == null)
        {
            instance = this;
        }
        //arrowProjectiles = new ObjectPool<GameObject>(CreateProjectilePoolObjects,OnSetProjectileActive,OnSetProjectileInactive);

    }
    //public GameObject CreateProjectilePoolObjects()
    //{
    //    //GameObject go = Instantiate(arrow);
    //    //arrow.gameObject.SetActive(false);
    //    return null;
    //}
    //void OnSetProjectileActive(GameObject projectile)
    //{   
    //    projectile.gameObject.SetActive(true);
    //}
    //void OnSetProjectileInactive(GameObject projectile)
    //{
    //   projectile.gameObject.SetActive(false);
    //}
    //public IEnumerator SpawnNumberOfProjectiles(float delayBetweenShots, float numberOfProjectiles, GameObject projectile,Transform spawnPos)
    //{
    //    for (int i = 0; i < numberOfProjectiles; i++)
    //    {
    //        Instantiate(projectile, spawnPos.position, spawnPos.rotation);
    //        yield return new WaitForSeconds(delayBetweenShots);
    //    }
    //}
    public void SpawnParticles(ParticleSystem particlesToSpawn,Transform spawnPosition, float destuctionTime)
    {
        Instantiate(particlesToSpawn, spawnPosition.position, spawnPosition.rotation);
        Destroy(particlesToSpawn, destuctionTime);
    }
}
