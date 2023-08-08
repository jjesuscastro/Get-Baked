using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Debug.Log("Touch detected");
                Vector2 raycast = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);

                RaycastHit2D raycastHit = Physics2D.Raycast(raycast, Vector2.zero);
                if (raycastHit)
                {
                    // Debug.Log("Something Hit");
                    if (raycastHit.collider.CompareTag("Food"))
                    {
                        raycastHit.transform.gameObject.GetComponent<Food>().Munch();
                    }
                }
            }
        }
    }
}
