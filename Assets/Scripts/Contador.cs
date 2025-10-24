using TMPro;
using UnityEngine;

public class Contador : MonoBehaviour
{
    public TextMeshProUGUI textoPontuacao;
    public static float Contar;
    
    void Start()
    {
        Contar = 0;
        textoPontuacao.text = Contar.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textoPontuacao.text = Contar.ToString();
    }
}
