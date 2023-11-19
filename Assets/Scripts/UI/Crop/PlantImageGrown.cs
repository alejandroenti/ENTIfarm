using UnityEngine;

public class PlantImageGrown : MonoBehaviour
{
    [SerializeField, Range(10f, 50f)] private float yOffset;
    [SerializeField, Range(0.5f, 3f)] private float animationSpeed;

    private Vector3 yUpOffset;
    private Vector3 yDownOffset;
    private Vector3 yTargetOffset;

    private bool isAnimated = false;

    private void Start()
    {
        yUpOffset = this.transform.position;
        yUpOffset.y = this.transform.position.y - yOffset;
       
        yDownOffset = this.transform.position;
        yDownOffset.y = this.transform.position.y + yOffset;
        
        yTargetOffset = yUpOffset;
    }

    private void Update()
    {
        if (isAnimated)
            PlayIdleAnimation();
    }

    public void SetIsAnimated(bool animated) => isAnimated = animated;

    private void PlayIdleAnimation()
    {
        this.transform.position = Vector3.Lerp(this.transform.parent.position, yTargetOffset, animationSpeed * Time.deltaTime);

        if (this.transform.position.y <= yTargetOffset.y && yTargetOffset == yUpOffset)
        {
            yTargetOffset = yDownOffset;
        }
        else if (this.transform.position.y >= yTargetOffset.y && yTargetOffset == yDownOffset)
        {
            yTargetOffset = yUpOffset;
        }
    }
}
