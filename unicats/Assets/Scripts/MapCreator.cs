using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block{
        public enum TYPE {
            NONE = -1,
            FLOOR = 0,
            HOLE,
            NUM,
        };
};

public class MapCreator : MonoBehaviour
{
    public static float BLOCK_WIDTH = 1.7f;
    public static float BLOCK_HEIGHT = 0.2f;
    public static int BLOCK_NUM_IN_SCREEN = 24;
    public TextAsset level_data_text = null;
    public GameManager theGM = null;

    private struct FloorBlock{
        public bool is_created;
        public Vector2 position;
    };

    private FloorBlock last_block;
    private PlayerControl player = null;
    private BlockCreator theBC;
    private LevelManager theLM;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        this.theBC = this.gameObject.GetComponent<BlockCreator>();
        this.last_block.is_created = false;
        this.theLM = new LevelManager();
        this.theLM.initialize();
        this.theLM.LoadLevelData(this.level_data_text);
        this.theGM = this.gameObject.GetComponent<GameManager>();
        this.player.theLM = this.theLM;
    }

    private void createMap(){
        Vector3 block_position;
        if(! this.last_block.is_created){
            block_position = this.player.transform.position;
            block_position.x -= BLOCK_WIDTH *((float)BLOCK_NUM_IN_SCREEN / 2.0f);
            block_position.y = 0.0f;                               
        } else{
            block_position = this.last_block.position;
        }
        block_position.x += BLOCK_WIDTH;
        //this.theBC.createBlock(block_position);
        this.theLM.update(this.theGM.getPlayTime());
        block_position.y = theLM.current_block.height * BLOCK_HEIGHT;
        LevelManager.CreationInfo current = this.theLM.current_block;
        if(current.block_type == Block.TYPE.FLOOR){
            this.theBC.createBlock(block_position);
        }
        this.last_block.position = block_position;
        this.last_block.is_created = true;

    }

    // Update is called once per frame 
    void Update()
    {
        float block_genenrate_x = this.player.transform.position.x;
        block_genenrate_x +=
            BLOCK_WIDTH * ((float)BLOCK_NUM_IN_SCREEN + 1)/2.0f;
        while(this.last_block.position.x < block_genenrate_x){
            this.createMap();
        }
    }
    public bool isDelete(GameObject block_object){
        bool ret = false;
        float left_limit = this.player.transform.position.x -
            BLOCK_WIDTH * ((float)BLOCK_NUM_IN_SCREEN / 2.0f);
        if(block_object.transform.position.x <left_limit){
            ret = true;
        }

        return(ret);
    }
}
