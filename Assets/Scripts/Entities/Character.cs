using UnityEngine;

public class Character : MonoBehaviour
{
    public float Speed = 5;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform art;

    void Update()
    {
        if (!GameManager.Instance.IsGameRunning) return;

        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
  
    private void Move()
    {        
        art.rotation = Quaternion.Euler(0,0,-Input.GetAxis("Horizontal")*17);

        transform.position += Speed * Time.deltaTime * new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

    } 

    private void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    public void OnDie()
    {        
        GameManager.Instance.OnCharacterDie();   
    }

}
