using System.Collections;
using UnityEngine;

public class Worker : MonoBehaviour // INHERITANCE (PARENT)
{
    // Protected/Private attributes
    protected float walkDuration = 1.5f;
    protected float coroutineWaitTime = 3.0f;

    // Protected/Private methods
    protected virtual void Start()
    {
        StartCoroutine(this.WalkCoroutine());
    }

    protected IEnumerator WalkCoroutine()
    {
        while (!GameDataManager.Instance.isGameOver)
        {
            yield return new WaitForSeconds(this.coroutineWaitTime);
            yield return this.Walk();
        }
    }

    protected virtual IEnumerator Walk() // POLYMORPHISM (PARENT)
    {
        float startRotation = this.transform.eulerAngles.y;
        float endRotation = startRotation + 360.0f;
        float t = 0.0f;

        while (t < this.walkDuration)
        {
            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, t / this.walkDuration) % 360.0f;
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, yRotation, this.transform.eulerAngles.z);

            yield return null;
        }
    }
}
