using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject PainelMenuPrincipal;
    [SerializeField] private GameObject PainelGameOver;
    [SerializeField] private SpriteRenderer Player;
    [SerializeField] private GameObject PlayButton;
    [SerializeField] private TextMeshProUGUI TextoContador;
    private float DefaultColor = 1f;
    private string TagCano = "CanoClone";

    public void Start()
    {
        PainelGameOver.SetActive(false);
        PainelMenuPrincipal.SetActive(true);
        Player.color = new Color(DefaultColor, DefaultColor, DefaultColor, 0f);
        TextoContador.color = new Color(DefaultColor, DefaultColor, DefaultColor, 0f);
        Time.timeScale = 0;
    }

    public void Play()
    {
        PainelMenuPrincipal.SetActive(false);
        PainelGameOver.SetActive(false);
        Player.color = new Color(DefaultColor, DefaultColor, DefaultColor, 1f);
        TextoContador.color = new Color(DefaultColor, DefaultColor, DefaultColor, 1f);
        Time.timeScale = 1;
    }

    public void DestruirCanos(){
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
        Player.color = new Color(DefaultColor, DefaultColor, DefaultColor, 1f);
        TextoContador.color = new Color(DefaultColor, DefaultColor, DefaultColor, 1f);
        Contador.Contar = 0;
        PainelMenuPrincipal.SetActive(false);
        Time.timeScale = 1;
    }
}
