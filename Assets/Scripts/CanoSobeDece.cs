using UnityEngine;

public class CanoSobeDece : MonoBehaviour
{
    private float velocidade = 5f;
    public bool cima = true;

    // Update is called once per frame
    void Update()
    {
        MoverSobeDece();
    }

    private void MoverSobeDece()
    {
        transform.Translate(velocidade * Time.deltaTime * Vector3.left);

        if (transform.position.x < -30f) Destroy(gameObject);


    }


}