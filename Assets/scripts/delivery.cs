using UnityEngine;

public class delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float delay = 1f;
    private void OnCollisionEnter2D(Collision2D collision)
  
    {
        Debug.Log("we have been collided");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Package")&& !hasPackage)
        { 

          Debug.Log("picked up Package");
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, delay);
        }

        if (collision.CompareTag("customer") && hasPackage)
        {
            Debug.Log("package delivered");
            hasPackage = false;
            Destroy(collision.gameObject, delay);

            GetComponent<ParticleSystem>().Stop();
        }
        
    }
}      
