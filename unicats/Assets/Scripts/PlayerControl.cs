using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float JumpVaule;
    public float SpeedVaule;
    public GameObject Player;
    public GameManager gm;
    public SpriteRenderer sr;
    public LevelManager theLM = null;
    
    public Image hpbar;
    public float PlayerMaxHp;
    public float PlayerHp;

    public int jumpCount;
    public Animator PlayerAnimator;
    public Rigidbody2D Player_rb;
    
    private void Awake()
    {
        PlayerAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Player_rb = Player.GetComponent<Rigidbody2D>();
        sr = Player.GetComponent<SpriteRenderer>();
        PlayerHp = PlayerMaxHp;
    }

    void Update(){
        //time 뭐시기 금지
        SpeedVaule = theLM.getPlayerSpeed();
        Player_rb.velocity = (new Vector2(SpeedVaule,Player_rb.velocity.y));
        PlayerHp -= theLM.timespeed * Time.smoothDeltaTime;
        hpbar.rectTransform.sizeDelta = new Vector2((PlayerHp / PlayerMaxHp) * 700, 100) ;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fish"))
        {
            StartCoroutine(punch());
            Timeincrese();
            gm.score += 100;
            SoundManager.instance.PlaySingle(SoundManager.instance.fisheatSound);
            Destroy(other.gameObject);
        }
        if (gm.score <= 0) gm.score = 0;
        if (PlayerHp <= 0) PlayerHp = 0;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.collider.CompareTag("map")){
            PlayerAnimator.SetBool("jamp", false);
            jumpCount = 0;
        }
    }

    IEnumerator Hit()
    {
        int countTime = 0;
        while(countTime < 3){
            Player.layer = 8;
            if(countTime % 2 == 0){
                sr.color = new Color32(255,255,255,90);
            }else{
                sr.color = new Color32(255,255,255,180);
            }
            yield return new WaitForSeconds(0.3f);
            countTime++;
        }
        Player.layer = 6;
        sr.color = new Color32(255,255,255,255);

        yield return null;
    }

    IEnumerator punch(){
        PlayerAnimator.SetBool("jamp", false);
        PlayerAnimator.SetBool("atake", true);
        yield return new WaitForSeconds(0.3f);
        PlayerAnimator.SetBool("atake", false);
        yield return null;
    }

    void Timeincrese(){
        PlayerHp += 3f;

        if(PlayerMaxHp < PlayerHp) {
            PlayerHp = PlayerMaxHp;
        }   
    }
    void Timedecrese(){
        PlayerHp -= 2.0f;

        if(0 > PlayerHp) {
            PlayerHp = 0;
        }   
    }

    public void jumpButton(){
            PlayerAnimator.SetBool("run", true);
            PlayerAnimator.SetBool("jamp", false);
            if (jumpCount == 0){
            PlayerAnimator.SetBool("jamp", true);
            Player_rb.velocity = new Vector3(Player_rb.velocity.x,JumpVaule,0);
            jumpCount += 1;
            }
    }

}
