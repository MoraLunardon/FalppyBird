using UnityEngine;

public class PlayerFlappyBird : MonoBehaviour
{
    public static PlayerFlappyBird Instance;
    
    private Rigidbody2D _rb2D;
    [SerializeField] private float velocidadePulo = 5f;
    [SerializeField] private  Animator _flappyAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Pular();
    }

    private void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb2D.linearVelocity = new Vector2(_rb2D.linearVelocity.x, velocidadePulo);
            _flappyAnimator.SetTrigger("Flap");
        }

        float ySpeedr = transform.position.y;
        _flappyAnimator.SetFloat("ySpeed", ySpeedr);
    }
    public void GameOver()
    {
        Time.timeScale = 1;
    }
}
