using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{
    //variabel
    [SerializeField] private float sensivity;

    //reference
    private Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!HUDManager.GameisPaused)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
            parent.Rotate(Vector3.up, mouseX);
        }
    }
}
