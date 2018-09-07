using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D enemyRigidBody;
    

	// Use this for initialization
	void Start () {
        enemyRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (IsFacingRight()) {
            enemyRigidBody.velocity = new Vector2(moveSpeed, 0f);
        }
        else {
            enemyRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }

        
	}

    private bool IsFacingRight() {
        return this.gameObject.transform.localScale.x > 0;
    }

    private void flipEnemy() {
        bool enemyHasHorizontalSpeed = Mathf.Abs(enemyRigidBody.velocity.x) > Mathf.Epsilon;

        if (enemyHasHorizontalSpeed) {
            this.gameObject.transform.localScale = new Vector2(Mathf.Sign(enemyRigidBody.velocity.x), 1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        this.gameObject.transform.localScale = new Vector2(-Mathf.Sign(enemyRigidBody.velocity.x), 1f);
    }
}
