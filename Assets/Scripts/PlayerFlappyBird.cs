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
    [SerializeField] private float velocidadePulo = 3f;
    [SerializeField] private float velocidadeRotacao = 5f;
    [SerializeField] private  Animator _flappyAnimator;
    [SerializeField] private TextMeshProUGUI TextoContador;
    [SerializeField] private GameObject PainelInfo;
    [SerializeField] private AudioClip somColisao;
    private float DefaultColor = 1f;
    private float BestScore = 0f;
    private bool _morreu = false;
    private AudioSource _metalPipe;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (_morreu) return;

        Pular();
        transform.rotation = Quaternion.Euler(0, 0, _rb2D.linearVelocity.y * velocidadeRotacao);
    }

    private void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb2D.linearVelocity = new Vector2(_rb2D.linearVelocity.x, velocidadePulo);
            _flappyAnimator.SetTrigger("Flap");
        }

        _flappyAnimator.SetFloat("ySpeed", _rb2D.linearVelocity.y);
    }

    private void Morto()
    {
        _morreu = true;
        Time.timeScale = 1;
        _flappyAnimator.SetTrigger("Death");
        _rb2D.linearVelocity = Vector2.zero;
        _rb2D.simulated = false;
        Invoke(nameof(GameOver), 10f);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Canos(Clone)") ||
        other.gameObject.CompareTag("Chão") ||
        other.gameObject.CompareTag("Teto"))
        {
            if (_metalPipe != null && somColisao != null)
            {
                _metalPipe.PlayOneShot(somColisao);
            }
            Morto();
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
