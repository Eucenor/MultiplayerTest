using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class Maker:MonoBehaviour{
    

   public void CreatePlayer(){
             GameObject player = (GameObject)PhotonNetwork.Instantiate("Player",new Vector3(518.1536f, 113.06f, 239.5019f),Quaternion.identity,0);
   }
}
