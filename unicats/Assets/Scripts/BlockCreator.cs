using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreator : MonoBehaviour
{
    public GameObject[] blockPrefabs;
    public int block_count = 0;
    
    public LevelManager theLM;
    int CurrentBlockType = 1;

    // Start is called before the first frame update
    void Start()
    {
        theLM = gameObject.GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createBlock(Vector2 block_position){
        //만들 블록의 종류 구분
        //0 = 장애물 맵
        //1 = 그냥 맵
        //2 = 아이템 맵
        int NextBlockType = Random.Range(0, blockPrefabs.Length);

        if(NextBlockType == 0){
            if(CurrentBlockType == 0){NextBlockType = Random.Range(1, blockPrefabs.Length);}

        }
        
        GameObject GoBlock =
            GameObject.Instantiate(this.blockPrefabs[NextBlockType]) as GameObject;
        //as 뭐임?

        GoBlock.transform.position = block_position;
        CurrentBlockType = NextBlockType;
        this.block_count++;
    }


}
