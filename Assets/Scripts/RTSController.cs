//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class RTSController : MonoBehaviour
//{
//    public Pathfinding pathfinding;

//    public List<Unit> Units = new List<Unit>();

//    private Vector3 startPos = Vector3.zero;
//    private Vector3 endPos = Vector3.zero;
//    [SerializeField]
//    private Text TextUI;

//    private string texto;

//    private void Start()
//    {

//    }

//    // Update is called once per frame
//    private void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            RaycastHit hit;
//            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//            if (Physics.Raycast(ray, out hit))
//            {
//                {
//                    if (hit.collider.gameObject.tag == "Building")
//                    {
//                        hit.collider.gameObject.GetComponent<Spawner>().LeftClicked();
//                    }
//                }
//            }
//        }
//        RightClick();
//        LeftClick();
//    }

//    private void RightClick()
//    {
//        if (Input.GetMouseButton(1))
//        {
//            RaycastHit hit;
//            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//            if (Physics.Raycast(ray, out hit))
//            {
//                if (hit.collider.gameObject.tag == "Ground")
//                {
//                    endPos = hit.point;
//                    for (int i = 0; i < Units.Count; i++)
//                    {
//                       // Units[i].SetPath(pathfinding.FindPath(Units[i].transform.position, endPos));
//                        Units[i].FSMUnit(Unit.States.Moving);
//                    }
//                    //Player.transform.position = new Vector3(endPos.x, endPos.y, endPos.z);
//                }
//                else if (hit.collider.gameObject.tag == "Unit" && hit.collider.gameObject.GetComponent<Unit>().isEnemy == false)
//                {

//                }
//                else if (hit.collider.gameObject.tag == "Unit" && hit.collider.gameObject.GetComponent<Unit>().isEnemy == true)
//                {

//                }
//            }
//        }
//    }

//    private void LeftClick()
//    {
//        if (Input.GetMouseButton(0))
//        {
//            for (int i = 0; i < Units.Count; i++)
//            {
//                texto += Units[i].Name;
//            }
//            TextUI.text = texto;
//            texto = null;
//            RaycastHit hit;
//            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//            if (Physics.Raycast(ray, out hit))
//            {
//                if (hit.collider.gameObject.tag == "Ground")
//                {
//                    Units.Clear();
//                }
//                else if (hit.collider.gameObject.tag == "Unit" && hit.collider.gameObject.GetComponent<Unit>().isEnemy == false)
//                {
//                    if (!Units.Contains(hit.collider.gameObject.GetComponent<Unit>()))
//                    {
//                        Units.Clear();
//                        Units.Add(hit.collider.gameObject.GetComponent<Unit>());
//                    }
//                }
//                else if (hit.collider.gameObject.tag == "Unit" && hit.collider.gameObject.GetComponent<Unit>().isEnemy == true)
//                {

//                }
//            }
//        }
//    }
//}
