using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度")]
    public float Speed;
    [Header("")]
    private Vector2 movement;

    private Animator anim;
    private Rigidbody2D rb;
    [Header("水平")]
    private float h;
    [Header("垂直")]
    private float v;

    #endregion

    #region 方法
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    #region 移動
    private void GetHorizontal()
    {
        //輸入取得軸向("水平")
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }
    private void Move()
    {
        //剛體.加速度 = 二維(水平 * 速度, 原本加速度.y)
        rb.velocity = new Vector2(h * Speed, v * Speed);

        //如果玩家按下D就執行
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //transform指的此腳本同一層的 transform元件
            // Rotation 角度在程式是 localEulerAngless
            transform.localEulerAngles = Vector3.zero;
        }
        //如果玩家按下A就執行
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        //如果玩家按下w就執行
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.localEulerAngles = new Vector3(0, -90, 0);
        }
        //如果玩家按下s就執行
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.localEulerAngles = new Vector3(0, 90, 0);
        }

        anim.SetBool("跑步開關", h != 0 || v != 0);
    }
    #endregion
    #endregion
}
