using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour
{

    public GameObject objectToFollow;

    public float speed = 5.0f;

    void Update()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = this.transform.position;
        position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y + 8.0f, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x + 5.0f, interpolation);
        position.z = Mathf.Lerp(this.transform.position.z, objectToFollow.transform.position.z - 5.0f, interpolation);

        this.transform.position = position;
    }
}