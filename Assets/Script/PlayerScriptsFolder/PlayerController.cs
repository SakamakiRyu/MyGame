using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Rigidbody を使って Humanoid タイプのキャラクターをアニメーションさせながら動かすコンポーネント
/// 入力を受け取り、それに従ってオブジェクトをメインカメラと相対的な方向に動かす。
/// </summary>
[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    /// <summary>現在の移動速度</summary>
    [SerializeField] public float m_movingSpeed;
    /// <summary>歩く速さ</summary>
    [SerializeField] private float m_walkSpeed = 5f;
    /// <summary>走る速さ</summary>
    [SerializeField] private float m_sprintSpeed = 8f;
    /// <summary>ターンの速さ</summary>
    [SerializeField] private float m_turnSpeed = 3f;
    /// <summary>ジャンプ力</summary>
    [SerializeField] private float m_jumpPower = 5f;
    /// <summary>接地判定の際、中心 (Pivot) からどれくらいの距離を「接地している」と判定するかの長さ</summary>
    [SerializeField] private float m_isGroundedLength = 1.1f;
    /// <summary>Playerの死ぬモーションを入れる</summary>
    [SerializeField] GameObject playerDeadPrefab = null;
    /// <summary>剣の当たり判定</summary>
    [SerializeField] Collider m_attackTrigger = null;
    /// <summary>盾の当たり判定</summary>
    [SerializeField] Collider shieldAttackTrigger = null;
    /// <summary>レベルが上がった際に再生するエフェクト</summary>
    [SerializeField] GameObject levelUpEffect;

    GameObject obj;
    Animator m_anim = null;
    Rigidbody m_rb = null;
    PlayerDate playerDate;
    float nowHeight = 0;
    /// <summary>trueで他の行動が可能。falseの間、現在の行動以外不可</summary>
    bool action = true;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_anim = GetComponent<Animator>();
        playerDate = GetComponent<PlayerDate>();
        m_movingSpeed = m_walkSpeed;
    }
    void Update()
    {
        // 方向の入力を取得し、方向を求める
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        // 入力方向のベクトルを組み立てる
        Vector3 dir = Vector3.forward * v + Vector3.right * h;

        if (dir == Vector3.zero)
        {
            // 方向の入力がニュートラルの時は、y 軸方向の速度を保持するだけ
            if (IsGrounded())
            {
                m_rb.velocity = new Vector3(0f, m_rb.velocity.y, 0f);
            }
            else if (!IsGrounded())
            {
                m_rb.velocity = new Vector3(this.m_rb.velocity.x, m_rb.velocity.y, this.m_rb.velocity.z);
            }
        }
        else if (IsGrounded() && action == true)
        {
            // カメラを基準に入力が上下=奥/手前, 左右=左右にキャラクターを向ける
            dir = Camera.main.transform.TransformDirection(dir);    // メインカメラを基準に入力方向のベクトルを変換する
            dir.y = 0;  // y 軸方向はゼロにして水平方向のベクトルにする

            // 入力方向に滑らかに回転させる
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * m_turnSpeed);  // Slerp を使うのがポイント

            Vector3 velo = dir.normalized * m_movingSpeed; // 入力した方向に移動する
            velo.y = m_rb.velocity.y;   // ジャンプした時の y 軸方向の速度を保持する
            m_rb.velocity = velo;   // 計算した速度ベクトルをセットする
        }

        if (Input.GetButtonDown("Sprint") && IsGrounded())
        {
            m_movingSpeed = m_sprintSpeed;
        }

        if (Input.GetButtonUp("Sprint"))
        {
            m_movingSpeed = m_walkSpeed;
        }

        // ジャンプの入力を取得し、接地している時に押されていたらジャンプする
        if (Input.GetButtonDown("Jump") && IsGrounded() && action == true)
        {
            m_rb.AddForce(Vector3.up * m_jumpPower, ForceMode.Impulse);
            m_anim.SetTrigger("Jump");
        }

        // 攻撃の入力を取得し、接地している時に押されていたら攻撃する
        if (Input.GetButtonDown("Fire1") && IsGrounded())
        {
            m_anim.SetTrigger("Attack");
        }

        if (Input.GetButtonDown("Fire2") && IsGrounded() && action == true)
        {
            action = false;
            m_anim.SetBool("Block", true);
            m_movingSpeed = 0;
        }
        if (Input.GetButtonUp("Fire2"))
        {
            action = true;
            m_anim.SetBool("Block", false);
        }

        // 接地しているかをを判定し接地してなかったら滞空アニメーションを再生する
        if (!IsGrounded())
        {
            Vector3 down = transform.TransformDirection(Vector3.down);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, down, out hit, 3f))
            {
                nowHeight = hit.distance;
            }
            m_anim.SetFloat("JumpMidAir", nowHeight);
        }

        if (playerDate.nowHitPoint <= 0)
        {
            Debug.Log("力尽きた、、、");
            Instantiate(playerDeadPrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Update の後に呼び出される。Update の結果を元に何かをしたい時に使う。
    /// </summary>
    void LateUpdate()
    {
        // 水平方向の速度を求めて Animator Controller のパラメーターに渡す
        Vector3 horizontalVelocity = m_rb.velocity;
        horizontalVelocity.y = 0;
        m_anim.SetFloat("Speed", horizontalVelocity.magnitude);
    }

    /// <summary>
    /// 地面に接触しているか判定する
    /// </summary>
    /// <returns></returns>
    bool IsGrounded()
    {
        // Physics.Linecast() を使って足元から線を張り、そこに何かが衝突していたら true とする
        Vector3 start = this.transform.position;   // start: オブジェクトの中心
        Vector3 end = start + Vector3.down * m_isGroundedLength;  // end: start から真下の地点
        Debug.DrawLine(start, end); // 動作確認用に Scene ウィンドウ上で線を表示する
        bool isGrounded = Physics.Linecast(start, end); // 引いたラインに何かがぶつかっていたら true とする

        return isGrounded;
    }

    /// <summary>
    /// 攻撃判定を有効にする
    /// </summary>
    void BeginAttack()
    {
        if (m_attackTrigger)
        {
            m_attackTrigger.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 攻撃判定を無効にする
    /// </summary>
    void EndAttack()
    {
        if (m_attackTrigger)
        {
            m_attackTrigger.gameObject.SetActive(false);
        }
    }

    void BeginSieldAttack()
    {
        if (shieldAttackTrigger)
        {
            shieldAttackTrigger.gameObject.SetActive(true);
        }
    }
    void EndSieldAttack()
    {
        if (shieldAttackTrigger)
        {
            shieldAttackTrigger.gameObject.SetActive(false);
        }
    }
    void MoveStop()
    {
        action = false;
        m_rb.velocity = Vector3.zero;
        m_movingSpeed = 0;
    }
    void MoveStart()
    {
        action = true;
        m_movingSpeed = m_walkSpeed;
    }
}
