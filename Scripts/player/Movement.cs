using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class Movement : MonoBehaviourPun
{
    public static Movement movement = null;
    [SerializeField] private float speed = 10;
    [SerializeField] private float jumpforce=10;
    [SerializeField] private Rigidbody body;
    [SerializeField] private PhotonView photonid;
    
    private void Awake(){
       
    }
    private void Start(){
        if(!body){
            body = GetComponent<Rigidbody>();
        }
        if(!photonid){
             photonid = GetComponent<PhotonView>();
        }
    }
    private void Update(){
        if(photonView.IsMine){
            float left = Input.GetAxisRaw("Horizontal");
            float up = Input.GetAxisRaw("Vertical");
            transform.position += new Vector3(speed*left*Time.deltaTime,0,speed * up * Time.deltaTime);
        }
    }
    private void FixedUpdate(){
        if(photonView.IsMine){
            if(Input.GetKeyDown(KeyCode.Space)){
                body.velocity = new Vector3(body.velocity.x,transform.up.y*jumpforce*Time.fixedDeltaTime,body.velocity.z);
            }
        }

    }
}
