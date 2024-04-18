using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int speed;
    //enemy로 통합
    void Start()
    {

    }

    void Update()
    {
        float fMove = Time.deltaTime * speed;
        transform.Translate(Vector3.left * fMove);

        if(transform.position.x < -15){
            Destroy(gameObject);
        }
    }
    
}
