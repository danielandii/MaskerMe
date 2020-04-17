using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject npcPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    public float ypos = -2;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(NpcWave());
    }

    private void spawnNpc() {
        GameObject a = Instantiate(npcPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * 2, ypos);
    }

    IEnumerator NpcWave(){
        while(true){
            yield return new WaitForSeconds(respawnTime * Random.Range(1,5));
            spawnNpc();
        }
    }
}
