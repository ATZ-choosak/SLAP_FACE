using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnemy : MonoBehaviour
{
   public static AnimationEnemy Instance;

    Animator animator;

    AudioSource audioSource;

    [SerializeField]
    private AudioClip[] damage, attack;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void takeAnimation()
    {
        animator.SetTrigger("IsDamage");
        audioSource.PlayOneShot(damage[Random.Range(0 , damage.Length - 1)]);
    }

    public void takeAttack()
    {
        animator.SetTrigger("IsAttack");
        
    }

    public void takeDamageToPlayer()
    {
        TurnBaseUIHandler.Instance.EnemyTakeDamageToPlayer();
        audioSource.PlayOneShot(attack[Random.Range(0, attack.Length - 1)]);
        HandControl.Instance.playDamage();
    }
}
