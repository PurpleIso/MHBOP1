using UnityEngine;

public class HelicopterSpawner : MonoBehaviour
{
    public static GameObject CurrentPlayerHelicopter { get; private set; }  // Static property to track current helicopter

    public GameObject[] helicopterPrefabs;  // Drag all your helicopter prefabs here in the Inspector
    public Transform spawnPoint;

    private GameObject currentHelicopter;
    private int currentIndex = 0;

    void Start()
    {
        SpawnHelicopter();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            SwitchHelicopter();
        }
    }
    void SpawnHelicopter()
    {
        if (helicopterPrefabs.Length == 0 || spawnPoint == null)
        {
            Debug.LogWarning("No helicopter prefabs or spawn point assigned.");
            return;
        }

        currentHelicopter = Instantiate(helicopterPrefabs[currentIndex], spawnPoint.position, spawnPoint.rotation);
        CurrentPlayerHelicopter = currentHelicopter;


        ThirdPersonCamera cameraController = Camera.main.GetComponent<ThirdPersonCamera>();
        if (cameraController != null)
        {
            cameraController.SetTarget(currentHelicopter.transform);
        }
        else
        {
            Debug.LogWarning("ThirdPersonCamera script not found on the main camera.");
        }
    }
    void SwitchHelicopter()
    {
        if (currentHelicopter != null)
        {
            Destroy(currentHelicopter);
        }

        currentIndex = (currentIndex + 1) % helicopterPrefabs.Length;
        SpawnHelicopter();
    }
}
