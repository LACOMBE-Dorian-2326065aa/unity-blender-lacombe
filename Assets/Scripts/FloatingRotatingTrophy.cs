using UnityEngine;

public class FloatingRotatingTrophy : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public float floatAmplitude = 0.25f;
    public float floatFrequency = 2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        float y = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = startPos + new Vector3(0, y, 0);
    }
}
