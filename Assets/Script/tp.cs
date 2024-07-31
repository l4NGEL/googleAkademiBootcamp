using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        // Iþýnlanma pozisyonunu al
        float x = PlayerPrefs.GetFloat("TeleportPosX");
        float y = PlayerPrefs.GetFloat("TeleportPosY");
        float z = PlayerPrefs.GetFloat("TeleportPosZ");
        Vector3 teleportPosition = new Vector3(x, y, z);
        player.transform.position = teleportPosition;
    }
}
