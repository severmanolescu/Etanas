using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookHere : MonoBehaviour
{
    [SerializeField] private ObjectTextPositionHandler objectText;

    private void Start()
    {
        objectText.gameObject.SetActive(false);
    }

    public void ShowText()
    {
        objectText.gameObject.SetActive(true);
    }
    public void HideText()
    {
        objectText.gameObject.SetActive(false);
    }
}
