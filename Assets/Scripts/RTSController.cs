using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RTSController : MonoBehaviour
{
    public List<Unit> Units = new List<Unit>();
    public Pathfinding pathfinding;

    [SerializeField]
    private LayerMask defaultLayer;
    [SerializeField]
    private LayerMask groundLayerMask;

    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        RightClick();
        LeftClick();
    }

    private void RightClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, groundLayerMask))
            {
                print(hit.collider.name);
                if (hit.collider.gameObject.tag == "Ground")
                {
                    for (int i = 0; i < Units.Count; i++)
                    {
                        Units[i].target.position = hit.point;
                        //pathfinding.FindPath(Units[i].transform.position, hit.point, Units[i].gameObject);
                        //Units[i].StartCoroutine(Units[i].FollowPath());
                    }
                }
            }
        }
    }

    private void LeftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                print(hit.collider.name);
                if (hit.collider.gameObject.tag == "Ground")
                {
                    foreach (Unit unit in Units)
                    {
                        unit.ChangeSelectionState(Unit.SelectionState.Unselected);
                    }
                    Units.Clear();
                }
                else if (hit.collider.gameObject.tag == "Unit")
                {
                    if (!Units.Contains(hit.collider.gameObject.GetComponent<Unit>()))
                    {
                        foreach (Unit unit in Units)
                        {
                            unit.ChangeSelectionState(Unit.SelectionState.Unselected);
                        }
                        Units.Clear();
                        Unit unidade = hit.collider.gameObject.GetComponent<Unit>();
                        Units.Add(unidade);
                        unidade.ChangeSelectionState(Unit.SelectionState.Selected);
                    }
                }
            }
        }
    }
}
