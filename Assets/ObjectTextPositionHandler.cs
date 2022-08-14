using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTextPositionHandler : MonoBehaviour
{
    [SerializeField] private Transform trackObject;
    [SerializeField] private float distanceFromObject;

    private Transform playerLocation;

    private void Awake()
    {
        playerLocation = GameObject.Find("MainCamera").transform;
    }

    void Update()
    {
        if(trackObject != null)
        {
            transform.LookAt(playerLocation);

            transform.position = trackObject.position + new Vector3(0f, distanceFromObject, 0f);
        }
    }
}

