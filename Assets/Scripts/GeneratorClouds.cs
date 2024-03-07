using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorClouds : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.1f;
    [SerializeField]
    private GameObject cloudPrefab;
    [SerializeField] 
    private int numberOfClouds = 50;
    [SerializeField] 
    private Vector2[] spawnArea;
    private List<GameObject> clouds;

    void Start()
    {
        clouds = new List<GameObject>();
        GenerateCloudsOnStart();
    }

    void FixedUpdate()
    {
        MoveClouds();
    }

    private void GenerateCloudsOnStart()
    {
        for (int i = 0; i < numberOfClouds; i++) {
            Vector2 spawnPosition = new Vector2(Random.Range(spawnArea[0].x, spawnArea[1].x), Random.Range(spawnArea[0].y, spawnArea[1].y));
            GameObject cloud = Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);
            cloud.transform.parent = transform;
            clouds.Add(cloud);
        }
    }

    private void GenerateCloudsOnUpdate(int countClouds)
    {
        for (int i = 0; i < countClouds; i++) {
            Vector2 spawnPosition = new Vector2(spawnArea[0].x, Random.Range(spawnArea[0].y, spawnArea[1].y));
            GameObject cloud = Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);
            cloud.transform.parent = transform;
            clouds.Add(cloud);
        }
    }

    private void MoveClouds()
    {
        for (int i = 0; i < clouds.Count; i++) {
            clouds[i].transform.Translate(Vector2.right * moveSpeed);
            DestroyCloud(clouds[i], i);
        }
    }

    private void DestroyCloud(GameObject cloud, int index)
    {
        if (cloud.transform.position.x >= spawnArea[1].x) {
            clouds.RemoveAt(index);
            Destroy(cloud);
            GenerateCloudsOnUpdate(1);
        }
    }
}
