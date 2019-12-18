using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public GameObject TpsCamera;
    public GameObject FpsCamera;
    void Start(){
        this.TpsCamera = GameObject.Find("CameraTps");
        this.TpsCamera.AddComponent<Camera>();
        this.TpsCamera.transform.Translate(0,2,0);
        this.FpsCamera = GameObject.Find("CameraFps");
        this.FpsCamera.AddComponent<Camera>();
        this.FpsCamera.SetActive(false);
        this.FpsCamera.transform.Translate(0,2,0);
    }

   void Update(){
       
       if(Input.GetKeyDown(KeyCode.T)){
           TpsCamera.SetActive(!TpsCamera.activeSelf);
           FpsCamera.SetActive(!FpsCamera.activeSelf);
       }
       
       
   }
}