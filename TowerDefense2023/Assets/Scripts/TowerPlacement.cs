using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{

    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private TowerSlot[] towerSlots;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if(hit.collider != null)
            {
                int towerSlotIndex = Array.IndexOf(towerSlots, hit.collider.GetComponent<TowerSlot>());
                if (towerSlotIndex != -1 && towerSlots[towerSlotIndex].tower == null)
                {
                    PlaceTower(towerSlotIndex);
                }
            }
        }
    }

    public void PlaceTower(int towerSlotIndex)
    {
        GameObject spawnTower = Instantiate(towerPrefab);
        towerSlots[towerSlotIndex].tower = spawnTower.GetComponent<Tower>();
        spawnTower.transform.position = towerSlots[towerSlotIndex].transform.position;
    }

}
