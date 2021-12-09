using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject safePlatformPrefab;

    public int safePlatformCount = 300;

    public void GeneratePlatform()
    {
        Vector2 spawnPosition = new Vector2();

        for (int i = 0; i < safePlatformCount; i++)
        {
            spawnPosition.y += Random.Range(.5f, 2.2f); 
            spawnPosition.x += Random.Range(-1.7f, 1.7f);

            Instantiate(safePlatformPrefab, spawnPosition, Quaternion.identity);
        }
    }


}
