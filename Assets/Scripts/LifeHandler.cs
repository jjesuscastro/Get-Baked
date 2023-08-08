using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeHandler : MonoBehaviour
{
    [SerializeField] private Transform lifeContainer;
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private GameObject heartBreakPrefab;
    public int Lives;

    public Action onGameOver;
    List<Image> heartImages = new List<Image>();

    private void Start()
    {
        for (int i = 0; i < Lives; i++)
        {
            GameObject _gO = Instantiate(heartPrefab, Vector3.zero, Quaternion.identity, lifeContainer);
            Animation _animation = _gO.GetComponent<Animation>();
            _animation.InDelay = 0.125f * i;

            heartImages.Add(_gO.GetComponent<Image>());
        }
    }

    public void LoseLife()
    {
        Lives--;
        if (Lives >= 0)
        {
            Transform _gO = heartImages[Lives].gameObject.transform;
            Instantiate(heartBreakPrefab, _gO.position, Quaternion.identity);
            heartImages[Lives].enabled = false;
        }

        if (Lives == 0)
        {
            if (onGameOver != null)
                onGameOver.Invoke();
        }
    }
}
