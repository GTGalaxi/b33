using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour
{

    public Vector3 targetAngle = new Vector3(0f, 345f, 0f);
    private Vector3 currentAngle;
    public float LerpSpeed = 0.001f;

    public void Start()
    {
        currentAngle = transform.eulerAngles;
    }

    public void Update()
    {
        currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime* LerpSpeed),
            Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime* LerpSpeed),
            Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime* LerpSpeed));

        transform.eulerAngles = currentAngle;
    }
}
