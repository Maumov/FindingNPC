using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private GameObject npcBasePrefab;
    [SerializeField] private List<GameObject> npcVisualPrefabs;
    [SerializeField] private List<SolidRectangle> spawnLocations;


    // Start is called before the first frame update
    void Start()
    {
        //SpawnNPC(spawnLocations[0].GetRandomPositionInsideArea());
        StartCoroutine(CreateSomeNPCs());
    }

    //Testing creation of NPCs
    IEnumerator CreateSomeNPCs() {
        for(int i = 0; i < 350; i++) {
            SpawnNPC(spawnLocations[0].GetRandomPositionInsideArea());
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

    GameObject RandomNPCVisual() {
        int random = Random.Range(0, npcVisualPrefabs.Count);
        return npcVisualPrefabs[random];
    }

    void SpawnNPC() {
        GameObject baseNPC = Instantiate(npcBasePrefab, RandomNPCLocation(), Quaternion.identity);
        GameObject visual = Instantiate(RandomNPCVisual(), baseNPC.transform);
        //visual.transform.parent = baseNPC.transform;
        //visual.transform.localPosition = Vector3.zero;
        //visual.transform.localRotation = Quaternion.identity;
    }

    void SpawnNPC(Vector3 position) {
        GameObject baseNPC = Instantiate(npcBasePrefab, position, Quaternion.identity);
        GameObject visual = Instantiate(RandomNPCVisual(), baseNPC.transform);
    }

    void SpawnNPC(Vector3 position, GameObject npc) {
        GameObject baseNPC = Instantiate(npcBasePrefab, position, Quaternion.identity);
        GameObject visual = Instantiate(npc, baseNPC.transform);
    }
    void SpawnNPC(GameObject npc) {
        GameObject baseNPC = Instantiate(npcBasePrefab, RandomNPCLocation(), Quaternion.identity);
        GameObject visual = Instantiate(npc, baseNPC.transform);
    }
}
