using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Health : MonoBehaviour, ITakeDamage
{
    public int Current { get; private set; }

    [SerializeField] //sólo se usa en los atributos privados
    private int max;

    [FormerlySerializedAs("onEntityDie")]
    public UnityEvent OnEntityDie;

    public UnityEvent OnEntityHit;

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
            OnEntityDie?.Invoke();
            // si no es nulo
        }
        else
        {
            OnEntityHit?.Invoke();
        }
    }   

}
