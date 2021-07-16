using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;
public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager instance = null;
    public GameObject connectedScreen;
    public GameObject disconnectedScreen;
    [SerializeField] private TMP_Text joinRoomText;
    [SerializeField] private TMP_Text CreateRoomText;
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private Maker maker;
    [SerializeField] private TMP_Text connectionStatus;

    byte buildindex = 0;
    void Awake(){
        if(instance!=null){
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        ConnectToServer();
    }
   public void ConnectToServer(){
       PhotonNetwork.ConnectUsingSettings();
   }
    public override void OnConnectedToMaster()
    {
        print("connected to photon server successfully");
        PhotonNetwork.AutomaticallySyncScene = true;
        connectionStatus.text = "Connected!";

    }
    public override void OnJoinedLobby()
    {
        print("lobby joined");
    }
   public void JoinRoom(){
       if(PhotonNetwork.IsConnected){
            PhotonNetwork.JoinRoom(joinRoomText.text);
        }
        else{
            print("connecting to server, please try again");
        }  
   }
   public void CreateRoom(){
       if(PhotonNetwork.IsConnected)
       PhotonNetwork.CreateRoom(CreateRoomText.text);
   }
   public void LeaveRoom(){
       PhotonNetwork.LeaveRoom();
   }
    public override void OnLeftRoom()
    {
        print("left the room :(");
    }
    public override void OnJoinedRoom()
    {
        print("_joined the room "+PhotonNetwork.CurrentRoom.Name+ " successfully ^^");
        PhotonNetwork.LoadLevel("GameScene");    
       SceneManager.sceneLoaded += OnSceneFinishedLoading; 
    
    }
    public override void OnCreatedRoom()
    {
        print("_created a room successfully :)");
       
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print("_failed to join room. "+message);
    }
    void OnSceneFinishedLoading(Scene scene,LoadSceneMode mode){
        if(scene.name == "GameScene"){
            maker.CreatePlayer();            
        }
    }
}
   
