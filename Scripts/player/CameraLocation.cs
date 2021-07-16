using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(0,4,-3);
        transform.rotation = Quaternion.AngleAxis(45,transform.right);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
