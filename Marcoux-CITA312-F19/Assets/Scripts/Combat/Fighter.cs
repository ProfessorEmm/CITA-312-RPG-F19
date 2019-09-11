using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] float weaponDamage = 5f;

        Health target;
        float timeSinceLastAttack = 0;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;

            // stop attacking the target if they are dead
            if (target.IsDead()) return;

            // move only if a target is NOT within range
           if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.transform.position);
            }
            else // in range, attack!
            {
                GetComponent<Mover>().Cancel();
                AttackBehavior();
            }
        }

        private void AttackBehavior()
        {
            // look at our traget 
            transform.LookAt(target.transform);

            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                // This will trigger the Hit() event
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack = 0f;
            }
            
        }

        // this is an animation event
        void Hit()
        {
            target.TakeDamage(weaponDamage);
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < weaponRange;
        }

        public bool CanAttack(CombatTarget combatTarget)
        {
            if (combatTarget == null)
            {
                return false;
            }
            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead();
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.GetComponent<Health>();
        }

        public void Cancel()
        {
            GetComponent<Animator>().SetTrigger("stopAttack");
            target = null;
        }

    } // class Fighter
} // namespace
