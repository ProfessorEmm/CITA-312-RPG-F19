using System;
using RPG.Movement;
using UnityEngine;
using RPG.Combat;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {

        private void Update()
        {
            InteractWithCombat();
            InteractWithMovement();
        }

        private void InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                // if the target is null, skip the rest of the statements in this foreach loop
                if (target == null) continue;
                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target);
                }
            }
        }

        private void InteractWithMovement()
        {
            // getting the location of the mouse
            if (Input.GetMouseButton(0))
            {
                // move to where the cursor is located
                MoveToCursor();
            }
        }

        private void MoveToCursor()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                GetComponent<Mover>().MoveTo(hit.point);
            }
        } // MoveToCursor

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    } // PlayerController

}