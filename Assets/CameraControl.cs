using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    Transform target;
    Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    private void Follow(){
        transform.position = target.position + distance;
    }
}
