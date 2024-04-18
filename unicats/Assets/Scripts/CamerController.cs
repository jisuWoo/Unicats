using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamerController : MonoBehaviour
{
    private GameObject player = null;
    private Vector3 position_offset = Vector3.zero;
    //아마도 카메라 컨트롤
    void Start()
    {
        Camera camera = GetComponent<Camera>(); //카메라 컴포넌트를 가져옵니다.
        Rect rect = camera.rect;
        float scaleheight = ((float)Screen.width / Screen.height) / ((float)16 / 9); // (가로 / 세로) 
        float scalewidth = 1f / scaleheight;
        if (scaleheight < 1)
        {
            rect.height = scaleheight;
            rect.y = (1f - scaleheight) / 2f;
        }
        else
        {
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }
        camera.rect = rect;
         
        void OnPreCull() {
            camera.ResetWorldToCameraMatrix();
            camera.ResetProjectionMatrix();
            camera.projectionMatrix = camera.projectionMatrix * Matrix4x4.Scale(new Vector3(1, -1, 1));
        }
        if(SceneManager.GetActiveScene().name == "GamePlay"){
            this.player = GameObject.FindGameObjectWithTag("Player");
            this.position_offset = this.transform.position - this.player.transform.position;
        }
    }

    void OnPreCull() => GL.Clear(true, true, Color.black);

    private void LateUpdate() {
        if(SceneManager.GetActiveScene().name == "GamePlay"){
            Vector3 new_position = this.transform.position;
            new_position.x = this.player.transform.position.x + this.position_offset.x;
            this.transform.position = new_position;    
        }
    }
}
