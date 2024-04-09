using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] float scanDistance = 7f;
    [SerializeField] LayerMask scanLayer;

    public Transform GetNearestTarget()
    {
        Transform result = null;

        Collider2D[] raycasts = Physics2D.OverlapCircleAll(transform.position, scanDistance, scanLayer);
        if (raycasts != null)
        {
            float minDistance = scanDistance;
            foreach(var raycast in raycasts)
            {
                float distance = Vector2.Distance(raycast.transform.position, transform.position);
                if(distance < minDistance)
                {
                    result = raycast.transform;
                    minDistance = distance;
                }
            }
        }
        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, scanDistance);
    }
}
