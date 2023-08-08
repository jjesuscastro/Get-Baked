using UnityEngine;
using UnityEngine.Events;

public class Animation : MonoBehaviour
{
    public AnimationType Type;
    public bool Loop;

    [Header("In")]
    public float InValue;
    public float InDuration;
    public float InDelay;
    public bool PlayOnStart;

    [Header("Out")]
    public float OutValue;
    public float OutDuration;
    public UnityEvent OnOut;


    void Start()
    {
        if (PlayOnStart)
        {
            switch (Type)
            {
                case AnimationType.MoveX:
                case AnimationType.MoveY:
                    MoveIn();
                    break;
                case AnimationType.Scale:
                    Scale();
                    break;
            }
        }
    }

    public void MoveIn()
    {
        if (Loop)
        {
            if (Type == AnimationType.MoveY)
                LeanTween.moveY(gameObject.GetComponent<RectTransform>(), InValue, InDuration).setEaseInBounce().setLoopPingPong().setDelay(InDelay);
            else
                LeanTween.moveX(gameObject, InValue, InDuration).setLoopPingPong().setDelay(InDelay);
        }
        else
        {
            if (Type == AnimationType.MoveY)
                LeanTween.moveY(gameObject.GetComponent<RectTransform>(), InValue, InDuration).setDelay(InDelay);
            else
                LeanTween.moveX(gameObject, InValue, InDuration).setDelay(InDelay);
        }
    }

    public void MoveOut(float _delay)
    {
        LeanTween.cancel(gameObject.GetComponent<RectTransform>());
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), OutValue, OutDuration).setDelay(_delay).setOnComplete(OnAnimationOut);
    }

    public void Scale()
    {
        if (Loop)
            LeanTween.scale(gameObject, new Vector3(InValue, InValue, InValue), InDuration).setLoopPingPong().setDelay(InDelay);
        else
            LeanTween.scale(gameObject, new Vector3(InValue, InValue, InValue), InDuration).setDelay(InDelay);
    }

    void OnAnimationOut()
    {
        if (OnOut != null)
            OnOut.Invoke();
    }

    public enum AnimationType
    {
        MoveY,
        Shake,
        Scale,
        MoveX
    }
}
