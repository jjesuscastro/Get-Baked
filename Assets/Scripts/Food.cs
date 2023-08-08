using System;
using UnityEngine;
using TMPro;

public class Food : MonoBehaviour
{
    [SerializeField] private TMP_Text lifeText;
    [SerializeField] private int life;
    [SerializeField] GameObject crumble;

    public Action<int> onFoodEaten;
    public Action onFoodFell;

    private int value;
    private bool isEaten = false;
    public bool ShowLife;

    private void Awake()
    {
        value = life;
        lifeText.enabled = ShowLife;
        lifeText.text = life.ToString("00");
    }

    private void Update()
    {
        transform.position -= transform.up * Time.deltaTime * 3;
    }

    public void Munch()
    {
        life--;
        if (life == 0)
        {
            DestroyFood();
            return;
        }

        lifeText.text = (life.ToString("00"));
    }

    private void DestroyFood()
    {
        isEaten = true;
        if (crumble != null)
            Instantiate(crumble, transform.position, Quaternion.identity);

        onFoodEaten.Invoke(value);
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        if (isEaten)
            return;

        onFoodFell.Invoke();
        Destroy(gameObject);
    }
}
