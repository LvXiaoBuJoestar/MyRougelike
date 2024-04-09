using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return instance; } }
    private static GameManager instance;

    public GameObject Player;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);

        instance = this;
    }
}
