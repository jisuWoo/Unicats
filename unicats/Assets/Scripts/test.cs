using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public PlayerControl thePC;
    public GameObject Player;
    Rigidbody2D Player_rb;
    public Animator PlayerAnimator;
    //int jumpCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimator = Player.GetComponent<Animator>();
        thePC = Player.GetComponent<PlayerControl>();
        Player_rb = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        PlayerAnimator.SetBool("run", true);
        PlayerAnimator.SetBool("jamp", false);
        if (thePC.jumpCount == 0)
        {
            PlayerAnimator.SetBool("jamp", true);
            Player_rb.velocity = new Vector3(Player_rb.velocity.x, thePC.JumpVaule, 0);
            thePC.jumpCount += 1;
        }
    }

}
