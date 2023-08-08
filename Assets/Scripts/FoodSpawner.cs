using System;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private GameObject cookie;
    [SerializeField] private GameObject oreo;
    [SerializeField] private GameObject macaron;
    [SerializeField] private GameObject broccoli;

    public Action<Food> onFoodSpawned;

    float minX;
    float maxX;
    float posX;
    Vector2 spawnLocation;
    float spawnRate = 1.5f;
    float nextSpawn = 0;

    private void Awake()
    {
        mainCamera = Camera.main;
        float offSet = Screen.width * 0.15f;
        minX = mainCamera.ScreenToWorldPoint(new Vector2(offSet, 0)).x;
        maxX = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width - offSet, 0)).x;
    }

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            float posX = UnityEngine.Random.Range(minX, maxX);
            spawnLocation = new Vector2(posX, 10f);

            if (UnityEngine.Random.Range(1f, 10f) <= 8.5f)
            {
                Food food = null;
                float valueChance = UnityEngine.Random.Range(0f, 10f);

                if (valueChance >= 9.5f)
                {
                    if (macaron != null)
                        food = Instantiate(macaron, spawnLocation, Quaternion.identity).GetComponent<Food>();
                }
                else if (valueChance >= 8.8f)
                {
                    if (oreo != null)
                        food = Instantiate(oreo, spawnLocation, Quaternion.identity).GetComponent<Food>();
                }
                else
                {
                    if (cookie != null)
                        food = Instantiate(cookie, spawnLocation, Quaternion.identity).GetComponent<Food>();
                }

                if (food != null)
                    onFoodSpawned.Invoke(food);
            }
            else
            {
                if (broccoli != null)
                    Instantiate(broccoli, spawnLocation, Quaternion.identity);
            }
        }
    }
}