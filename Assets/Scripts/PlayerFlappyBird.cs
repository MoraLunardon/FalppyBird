using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerFlappyBird : MonoBehaviour
{
    public static PlayerFlappyBird Instance;
    
    private Rigidbody2D _rb2D;
    [SerializeField] private TextMeshProUGUI BSText;
    [SerializeField] private GameObject PainelGameOver;
    [SerializeField] private SpriteRenderer Player;
    [SerializeField] private float velocidadePulo = 5f;
    [SerializeField] private  Animator _flappyAnimator;
    [SerializeField] private TextMeshProUGUI TextoContador;
    [SerializeField] private GameObject PainelInfo;
    private float DefaultColor = 1f;
    private float BestScore = 0f;
    
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

    public void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Canos(Clone)"))
        {
            GameOver();
        }
        else{
        if (other.gameObject.CompareTag("Chão"))
        {
            GameOver();
        }
        if (other.gameObject.CompareTag("Teto"))
        {
            GameOver();
        }
        }
    }

    public void GameOver()
    {
        if(Contador.Contar > BestScore){
            BestScore = Contador.Contar;
        }

        BSText.text = BestScore.ToString();

        Player.color = new Color(DefaultColor, DefaultColor, DefaultColor, 0f);
        TextoContador.color = new Color(DefaultColor, DefaultColor, DefaultColor, 0f);
        PainelInfo.SetActive(false);
        PainelGameOver.SetActive(true);
        Time.timeScale = 0;
    }
}
