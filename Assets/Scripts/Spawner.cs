//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UIElements;

//public class Spawner : MonoBehaviour
//{
//    [SerializeField]
//    private GameObject prefab, panel, spawnPoint;
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

//    public void LeftClicked()
//    {
//        panel.SetActive(!panel.activeSelf);
//    }

//    public void GenerateUnit()
//    {
//        GameObject unit = Instantiate(prefab, spawnPoint.transform.position, Quaternion.identity, GameObject.Find("Units").transform);
//        Unit unitScript = unit.GetComponent<Unit>();
//        unitScript.targetPos = transform.Find("WaitPoint").position;
//        unitScript.FSMUnit(Unit.States.Moving);
//    }
//}
