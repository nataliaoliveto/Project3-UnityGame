using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, ITakeDamage
{
    public int Current { get; private set; }

    [SerializeField]
    private int max;

    [SerializeField]
    private UnityEvent onEntityDie;

    private bool _isDead;

    // Se ejecuta cuando se crea el objeto
    private void Awake()
    {
        Current = max;
    }
       
    public void TakeDamage(int damage)
    {
        if (_isDead) return;
        

        Current = Mathf.Clamp(Current - damage, 0, max);

        if(Current <= 0)
        {
            _isDead = true;
            onEntityDie?.Invoke();
            // si no es nulo
        }
    }   

}
