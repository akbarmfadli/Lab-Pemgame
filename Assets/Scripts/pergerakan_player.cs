using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pergerakan_player : MonoBehaviour
{
    //variable
    private float kecepatan = 7f;
    public float x;
    public float z;

    //reference
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        bergerak();
    }

    private void bergerak()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        Vector3 gerakan = transform.right * x + transform.forward * z;
        controller.Move(gerakan * kecepatan * Time.deltaTime);
    }
}

