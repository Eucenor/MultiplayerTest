using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AssignColor : MonoBehaviour
{
   void Start(){
       Renderer renderer = GetComponent<Renderer>();
        GetComponent<Renderer>().material.color =  new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f));
       print("color updated");
   }
}
