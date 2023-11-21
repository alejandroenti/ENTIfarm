using UnityEngine;

public class PlantImageGrown : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float amplitude;
    [SerializeField, Range(2f, 10f)] private float frequency;

    private bool isAnimated = false;

    private void Update()
    {
        if (isAnimated)
            PlayIdleAnimation();
    }

    public void SetIsAnimated(bool animated) => isAnimated = animated;

    private void PlayIdleAnimation()
    {
        this.transform.position = new Vector3(this.transform.parent.position.x, Mathf.Sin(Time.realtimeSinceStartup * frequency) * amplitude + this.transform.position.y, this.transform.parent.position.z);
    }
}
