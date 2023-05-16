using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControll : MonoBehaviour
{
    Animator animator;
    int isAttackingHash;
    int isShootingHash;
    private bool isCollidingWithEnemy = false;
    public MenuControll menuControl;

    //public Transform enemyTile;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isAttackingHash = Animator.StringToHash("isAttack");
        isShootingHash = Animator.StringToHash("isShooting");
        
    }

    // Update is called once per frame
    void Update()
    {
        bool pressLeftMouse = Input.GetMouseButton(0);
        bool isAttack = animator.GetBool("isAttack");
        if (pressLeftMouse & !isAttack)
        {
            animator.SetBool(isAttackingHash, true);
            animator.SetBool(isShootingHash, true);
        }
        if (!pressLeftMouse & isAttack)
        {
            animator.SetBool(isAttackingHash, false);
            animator.SetBool(isShootingHash, false);
        }
        if (isCollidingWithEnemy)
        {
            animator.SetBool("isDie", true);
            MenuControll.instance.GameOver();
            StartCoroutine(DelayToStop());
        }
    }
    private IEnumerator DelayToStop()
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isCollidingWithEnemy = true;
        }
    }

}
