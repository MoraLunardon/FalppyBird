using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject PainelMenuPrincipal;
    [SerializeField] private SpriteRenderer Player;
    [SerializeField] private TextMeshProUGUI Contador;
    [SerializeField] private GameObject PlayButton;
    private float DefaultColor = 1f;

    public void Start()
    {
        PainelMenuPrincipal.SetActive(true);
        Player.color = new Color(DefaultColor, DefaultColor, DefaultColor, 0f);
        Contador.color = new Color(DefaultColor, DefaultColor, DefaultColor, 0f);
        Time.timeScale = 0;
    }

    public void Play()
    {
        PainelMenuPrincipal.SetActive(false);
        Player.color = new Color(DefaultColor, DefaultColor, DefaultColor, 1f);
        Contador.color = new Color(DefaultColor, DefaultColor, DefaultColor, 1f);
        Time.timeScale = 1;
    }
}
