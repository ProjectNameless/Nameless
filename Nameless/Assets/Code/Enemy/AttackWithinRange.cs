using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWithinRange : MonoBehaviour {
    public GameObject target;
    public float attackRange;
    public Animation anim;
    public MeleeWeaponTrail attackTrail;

    public bool autoTargetPlayer = true;
    private List<GameObject> damageList = new List<GameObject>();

    //Is called when the attack succeeds
    private void OnTriggerEnter(Collider other)
    {
        if (!damageList.Contains(other.gameObject))
        {
            var weapon = GetComponentInChildren<Weapon>();
            Debug.Log("Apply " + weapon.damage + " damage to target.");
            damageList.Add(other.gameObject);
        }
    }

    private void Start()
    {
        if (autoTargetPlayer)
            target = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (anim.isPlaying)
            return;
        else if (attackTrail != null)
            attackTrail.Emit = false;

        var diff = target.transform.position - transform.position;
        if (diff.magnitude <= attackRange)
        {
            damageList.Clear();
            anim.Play();
            if (attackTrail != null)
                attackTrail.Emit = true;
        }
    }
}
