using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
public class NewMonoBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Sprite[] spriteUp;
    public Sprite[] spriteDown;
    public Sprite[] spriteLeft;
    public Sprite[] spriteRight;
    public float frameTime = 0.15f;
    private Rigidbody2D rb;
    public SpriteRenderer sr;
    private Vector2 input;
    private Vector2 velocity;
    private Sprite[] currentSprites;
    private int frameIndex = 0;
    private float timer = 0f;
    public int PlayerHp = 0;
    public int PlayerAttack = 0;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        currentSprites = spriteDown;
        sr.sprite = currentSprites[0];

        moveSpeed = GameDataManager1.Instance.GetPlayerMoveSpeed();
        PlayerHp = GameDataManager1.Instance.GetPlayerHp();
        PlayerAttack = GameDataManager1.Instance.GetPlayerAttack();
    }

    void Start()
    {
        if(GameDataManager1.Instance.isTutorialFinished == 0)
        {
            Debug.Log("튜토리얼 오픈!!");
            GameDataManager1.Instance.isTutorialFinished = 1;
        }
        else
        {
            //튜토리얼 했을 경우 아무것도 안 함
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameOverUI gameOverUI = FindFirstObjectByType<GameOverUI>();

            if (gameOverUI != null)
            {
                gameOverUI.ShowGameOver();
            }
            else
            {
                Debug.LogError("GameOverUI가 씬에 없습니다!");
            }
        }
    }


    public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
        velocity = input.normalized * moveSpeed;

        if (input.sqrMagnitude > 0.01f)
        {
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                if (input.x > 0)
                {
                    ChangeSprites(spriteRight);
                }
                else
                {
                    ChangeSprites(spriteLeft);
                }
            }
            else
            {
                if (input.y > 0)
                {
                    ChangeSprites(spriteUp);
                }
                else
                {
                    ChangeSprites(spriteDown);
                }
            }
        }

    }
    private void Update()
    {
        if (input.sqrMagnitude <= 0.01f)
        {
            frameIndex = 0;
            sr.sprite = currentSprites[frameIndex];
            return;
        }

        timer += Time.deltaTime;

        if (timer >= frameTime)
        {
            timer = 0f;
            frameIndex++;

            if (frameIndex >= currentSprites.Length)
            {
                frameIndex = 0;
            }
            sr.sprite = currentSprites[frameIndex];
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    private void ChangeSprites(Sprite[] newSprites)
    {
        if (currentSprites == newSprites)
        {
            return;
        }
        currentSprites = newSprites;
        frameIndex = 0;
        timer = 0f;
        sr.sprite = currentSprites[frameIndex];
    }
    public void SpeedUp(float value)
    {
        moveSpeed += value;
        velocity = input.normalized * moveSpeed;
    }

}