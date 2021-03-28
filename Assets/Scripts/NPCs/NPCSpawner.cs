using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> npcPrefabs;
    [SerializeField] private List<Transform> spawnLocations;


    // Start is called before the first frame update
    void Start()
    {
        CreateSomeNPCs();
    }

    //Testing creation of NPCs
    void CreateSomeNPCs() {
        for(int i = 0; i< spawnLocations.Count; i++) {
            SpawnNPC(spawnLocations[i].position);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomNPCLocation() {
        int random = Random.Range(0, spawnLocations.Count);
        return spawnLocations[random].position;
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
