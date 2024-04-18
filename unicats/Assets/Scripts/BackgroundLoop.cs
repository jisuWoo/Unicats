using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    //배경루프용
    public float scrollSpeed; 
    float targetoffset;
    Renderer m_renderer;

    void Start()
    {
       m_renderer= GetComponent<Renderer>();
    }

    void Update()
    {
        targetoffset += Time.deltaTime * scrollSpeed;
        m_renderer.material.mainTextureOffset = new Vector2(targetoffset, 0);
        m_renderer.material.SetTextureOffset("_BumpMap", new Vector2(targetoffset, 0)); // 노말 맵 텍스처도 동일한 오프셋을 적용합니다.
    }
}
