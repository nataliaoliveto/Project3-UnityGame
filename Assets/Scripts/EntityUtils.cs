using System.Collections;
using UnityEngine;


public class EntityUtils : MonoBehaviour
{
    public void DestroyEntity()
    {
        Destroy(gameObject);
    }

    public void AddScore(int score)
    {
        // muerte por kill
        GameManager.Instance.AddScore(score);
    }

}
