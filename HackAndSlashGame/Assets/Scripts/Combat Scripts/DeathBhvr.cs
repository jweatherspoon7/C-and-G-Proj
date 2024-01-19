using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathBhvr : StateMachineBehaviour
{
    GameObject gameObject;
    LevelHandler handler;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gameObject = animator.gameObject;

        if (gameObject.CompareTag("Boss"))
        {
            handler = gameObject.GetComponent<JonathanController>().levelHandler;
            if (handler != null) { handler.KilledEnemy(gameObject); }
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            handler = gameObject.GetComponent<EnemyController>().levelHandler;
            if (handler != null) { handler.KilledEnemy(gameObject); }

            gameObject.GetComponent<Rigidbody>().detectCollisions = false;
        }
        else if (gameObject.CompareTag("Player"))
        {
            handler = gameObject.GetComponent<StateController>().levelHandler;
            if (handler != null) { handler.PlayerDeath(); }
        }
    }
}
