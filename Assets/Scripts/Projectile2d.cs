using UnityEngine;

public class Projectile2d : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject crosshair;
    [SerializeField] Rigidbody2D bulletPrefab;
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //shoot raycast to detect mouse clicked position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.red, 3f);
            
            //get click point
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            
            //if hit object with collider
            if (hit.collider != null)
            {
                crosshair.transform.position = new Vector2(hit.point.x, hit.point.y);
                Debug.Log("Hit!!" + hit.collider.name);
                
                //calculate projetile velocity
                Vector2 projectileVelocity = CalculateProjectileVelocity(shootPoint.position, hit.point, 1f);
                
                //shoot bullet prefab using rigdbody2d
                Rigidbody2D shootBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
                
                //add projectile velocity vector to the bullet rigidbody
                shootBullet.linearVelocity = projectileVelocity;
            }
        }
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 crosshair, float time)
    {
        Vector2 distance = crosshair - origin;
        
        //find velocity of x and y axis
        float VelocityX = distance.x / time;
        float VelocityY = distance.y / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;
        
        //get projectile vector
        Vector2 projectileVelocity = new Vector2(VelocityX, VelocityY);
        
        return projectileVelocity;
    }
}
