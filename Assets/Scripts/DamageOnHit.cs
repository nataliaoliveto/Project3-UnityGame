using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DamageOnHit : MonoBehaviour
{

    [SerializeField]
    private int amount = 1;

    [SerializeField]
    private UnityEvent onHit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ITakeDamage damageable = other.GetComponent<ITakeDamage>();

        if(damageable != null)
        {
            damageable.TakeDamage(amount);
            onHit?.Invoke();
        }

    }

}