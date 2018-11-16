using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttacker : MonoBehaviour {



    public GameObject player;

    public float speed;

    public float maximumdistance;

    public float minimumdistance;

    public GameObject bullet;

    public float shootingtimer;

    public float shootingtimermax;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update () {

        if (Vector3.Distance(this.transform.position,player.transform.position) > maximumdistance)
        {
            this.GetComponent<Transform>().Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        }
        if (Vector3.Distance(this.transform.position, player.transform.position) < minimumdistance)
        {
            this.GetComponent<Transform>().Translate(Vector3.forward * -speed * Time.deltaTime, Space.Self);
        }
        if(Vector3.Distance(this.transform.position, player.transform.position) > minimumdistance && Vector3.Distance(this.transform.position, player.transform.position) < maximumdistance)
        {
            shootingtimer -= 1 * Time.deltaTime;
        }
        if(shootingtimer < 0)
        {

            shootingtimer = shootingtimermax;

            GameObject shotbullet = Instantiate(bullet, this.transform.position, this.transform.rotation);

            shotbullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 800);

        }
    }

    private void FixedUpdate()
    {
        this.transform.LookAt(player.transform.position);


    }
}
