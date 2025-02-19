using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DesactivateRay : MonoBehaviour
{
    [SerializeField] InputActionProperty leftActionProperty;
    [SerializeField] InputActionProperty rightActionProperty;
    [SerializeField] GameObject leftRay;
    [SerializeField] GameObject rightRay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftRay.SetActive(leftActionProperty.action.ReadValue<float>() > 0.1f);
        rightRay.SetActive(rightActionProperty.action.ReadValue<float>() > 0.1f);
    }
}
