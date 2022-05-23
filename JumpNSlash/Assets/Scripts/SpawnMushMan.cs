using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMushMan : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject spawnCreature;
    float spawnTime;
    
    void Start()
    {
        StartCoroutine(SpawnSystem());
    }
    IEnumerator SpawnSystem()
    {
        while (true)
        {
            spawnTime = Random.Range(3, 5);
            yield return new WaitForSeconds(spawnTime);
            MakeObject();
        }
    }
    void MakeObject()
    {
        GameObject temp = Instantiate(spawnCreature);
        temp.transform.position = spawnPoint.position;
    }
}
