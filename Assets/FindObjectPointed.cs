using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObjectPointed : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private float raycastRadius = 1f;
    [SerializeField] private float raycastDistance = 10f;

    private RaycastHit hit;

    private new Camera camera;

    private CameraLookHere lastObject;

    private void Awake()
    {
        camera = Camera.main;
    }

    void Update()
    {

        var cameraCenter = camera.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, camera.nearClipPlane));
        if (Physics.SphereCast(cameraCenter, raycastRadius, this.transform.forward, out hit, raycastDistance, layerMask))
        {
            var obj = hit.transform.gameObject;

            if (obj != null)
            {
                CameraLookHere cameraLook = obj.GetComponent<CameraLookHere>();

                if (cameraLook != null)
                {
                    if (lastObject == null || cameraLook != lastObject)
                    {
                        cameraLook.ShowText();

                        if (lastObject != null)
                        {
                            lastObject.HideText();
                        }

                        lastObject = cameraLook;
                    }
                }
            }
            else
            {
                if (lastObject != null)
                {
                    lastObject.HideText();

                    lastObject = null;
                }

            }
        }
        else
        {
            if (lastObject != null)
            {
                lastObject.HideText();

                lastObject = null;
            }
        }
    }
}

