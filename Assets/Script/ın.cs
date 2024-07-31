using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionScript : MonoBehaviour
{
    public GameObject player; // Karakter referansı
    public string targetSceneName = "TargetScene"; // Hedef sahnenin adı
    public Vector3[] teleportPositions; // Rastgele ışınlanma pozisyonları

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Etkileşim logic'i
            RaycastHit hit;
            if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, 3f))
            {
                if (hit.collider.gameObject.name == "X")
                {
                    // Rastgele pozisyon seçimi
                    Vector3 randomPosition = teleportPositions[Random.Range(0, teleportPositions.Length)];
                    // Hedef sahneye yükleme
                    SceneManager.LoadScene(targetSceneName);
                    // Işınlanma pozisyonunu PlayerPrefs ile kaydetme
                    PlayerPrefs.SetFloat("TeleportPosX", randomPosition.x);
                    PlayerPrefs.SetFloat("TeleportPosY", randomPosition.y);
                    PlayerPrefs.SetFloat("TeleportPosZ", randomPosition.z);
                }
            }
        }
    }
}
