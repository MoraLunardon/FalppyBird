using UnityEngine;

public class CanoIndividual : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        var obj = other.gameObject.GetComponent<PlayerFlappyBird>();

        if (obj == null) return;

        obj.GameOver();
    }
}
