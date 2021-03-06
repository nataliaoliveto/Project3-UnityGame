using UnityEngine;

public class EntityUtils : MonoBehaviour
{
    public void DestroyEntity()
    {
        Destroy(gameObject);
    }

    public void DestroyEntityAfterSeconds(float seconds)
    {        
        Destroy(gameObject, seconds);
    }

    public void DisableColliders()
    {
        var entityCollider = GetComponent<Collider2D>();
        if (entityCollider != null)
        {
            entityCollider.enabled = false;
        }
    }

    public void AddScore(int score)
    {
        GameManager.Instance.AddScore(score);
    }

}
