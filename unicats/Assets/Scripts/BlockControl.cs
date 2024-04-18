using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControl : MonoBehaviour
{
    public MapCreator theMC = null;

    // Start is called before the first frame update
    void Start()
    {
        theMC =  GameObject.Find("GameManager").GetComponent<MapCreator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.theMC.isDelete(this.gameObject)){
            GameObject.Destroy(this.gameObject);
        }
    }
}
