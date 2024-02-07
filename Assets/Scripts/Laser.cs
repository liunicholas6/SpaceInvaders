using UnityEngine;

public class Laser : MonoBehaviour
{
    public static bool activeLaser = false;
    
    public Vector3 speed;
    public bool isActive = true;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = speed;
        activeLaser = true;
    }

    private void Update()
    {
        float height = Screen.height;
        if (Camera.main.WorldToScreenPoint(gameObject.transform.position).y > height)
        {
            activeLaser = false;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isActive)
        {
            Collider collider = collision.collider;
            if (collider.CompareTag("Alien"))
            {
                IKillable alien = collider.gameObject.GetComponent<IKillable>();
                alien.Die();
                var contact = collision.contacts[0];
                collider.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(contact.normal, contact.point, ForceMode.Impulse);
            }
            else if (collider.CompareTag("Shield"))
            {
                ShieldBlock shieldBlock = collider.gameObject.GetComponent<ShieldBlock>();
                shieldBlock.Damage();
            }
    
            activeLaser = false;
            isActive = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;

            gameObject.layer = LayerMask.NameToLayer("DeadWeight");
        }
        else
        {
            
        }
        
    }
}