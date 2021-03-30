using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> npcPrefabs;
    [SerializeField] private List<SolidRectangle> spawnLocations;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateSomeNPCs());
    }

    //Testing creation of NPCs
    IEnumerator CreateSomeNPCs() {
        for(int i = 0; i < 100f; i++) {
            SpawnNPC(spawnLocations[0].GetRandomPositionInsideArea(),RandomNPC());
            yield return null;
        }
        yield return null;
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomNPCLocation() {
        int random = Random.Range(0, spawnLocations.Count);
        return spawnLocations[random].GetRandomPositionInsideArea();
    }

    GameObject RandomNPC() {
        int random = Random.Range(0, npcPrefabs.Count);
        return npcPrefabs[random];
    }

    void SpawnNPC() {
        Instantiate(RandomNPC(), RandomNPCLocation(), Quaternion.identity);
    }

    void SpawnNPC(Vector3 position) {
        Instantiate(RandomNPC(), position, Quaternion.identity);
    }

    void SpawnNPC(Vector3 position, GameObject npc) {
        Instantiate(npc, position, Quaternion.identity);
    }
    void SpawnNPC(GameObject npc) {
        Instantiate(npc, RandomNPCLocation(), Quaternion.identity);
    }
}
