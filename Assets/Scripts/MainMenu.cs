using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject PainelMenuPrincipal;
    [SerializeField] private GameObject PainelGameOver;
    [SerializeField] private SpriteRenderer Player;
    [SerializeField] private GameObject FlappyBird;
    [SerializeField] private GameObject PlayButton;
    [SerializeField] private TextMeshProUGUI TextoContador;
    [SerializeField] private GameObject PainelInfo;
    [SerializeField] private GameObject PainelPause;
    private Rigidbody2D _rb2D;
    private float DefaultColor = 1f;
    private string TagCano = "CanoClone";
    private bool IsAlive = false;

    public void Start()
    {
        _rb2D = FlappyBird.GetComponent<Rigidbody2D>();
        DestruirCanos();
        Player.transform.position = new Vector3(-6.44f,1.2f,0f);
        _rb2D.linearVelocity = new Vector2(0,0);
        PainelPause.SetActive(false);
        PainelGameOver.SetActive(false);
        PainelMenuPrincipal.SetActive(true);
        PainelInfo.SetActive(false);
        Player.color = new Color(DefaultColor, DefaultColor, DefaultColor, 0f);
        TextoContador.color = new Color(DefaultColor, DefaultColor, DefaultColor, 0f);
        Time.timeScale = 0;
        _rb2D = FlappyBird.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Pause();

        if(Player.color == new Color(DefaultColor, DefaultColor, DefaultColor, 0f)){
            IsAlive = true;
        }
        else{
            if(Player.color == new Color(DefaultColor, DefaultColor, DefaultColor, 1f)){
                IsAlive = false;
            }
        }
     }

    public void Play()
    {
        PainelMenuPrincipal.SetActive(false);
        PainelGameOver.SetActive(false);
        PainelInfo.SetActive(true);
        Player.color = new Color(DefaultColor, DefaultColor, DefaultColor, 1f);
        TextoContador.color = new Color(DefaultColor, DefaultColor, DefaultColor, 1f);
        Time.timeScale = 1;
    }

    public void DestruirCanos()
    {
        GameObject[] Clones = GameObject.FindGameObjectsWithTag(TagCano);

        foreach (GameObject CloneCano in Clones)
        {
            Destroy(CloneCano);
        }
    }

    public void Retry(){
        DestruirCanos();
        PainelMenuPrincipal.SetActive(false);
        PainelGameOver.SetActive(false);
        Player.transform.position = new Vector3(-6.44f,1.2f,0f);
        _rb2D.linearVelocity = new Vector2(0,0);
        Player.color = new Color(DefaultColor, DefaultColor, DefaultColor, 1f);
        TextoContador.color = new Color(DefaultColor, DefaultColor, DefaultColor, 1f);
        Contador.Contar = 0;
        PainelMenuPrincipal.SetActive(false);
        PainelInfo.SetActive(true);
        Time.timeScale = 1;
    }

    public void Pause(){
        if(Input.GetKey(KeyCode.Escape)){
            if(IsAlive){
                PainelPause.SetActive(false);
                PainelInfo.SetActive(true);
            }
            else{
                PainelPause.SetActive(true);
                PainelInfo.SetActive(false);
                Time.timeScale = 0;
            }
        }
    }

    public void Resume(){
        PainelPause.SetActive(false);
        PainelInfo.SetActive(true);
        Time.timeScale = 1;
    }

    public void ExitGame(){
        Application.Quit();
    }
}