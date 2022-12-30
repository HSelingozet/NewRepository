using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 distance;

    void Start()
    {
        distance = transform.position - target.position;
    }

    void Update()
    {
        transform.position = target.position + distance;

    }
}