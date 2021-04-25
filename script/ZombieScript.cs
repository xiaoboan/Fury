using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ZombieScript : MonoBehaviour {

    public bool isHit = false;
    NavMeshAgent navAgent;
    GameObject player;
    public float stopDistance;
	public float level;
    public Animator anim;
	public static string loadName="gameover";
// Use this for initialization
    void Start () {
        gameObject.GetComponent<Animator> ().Play("Z_Run");
        navAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

// Update is called once per frame
    void Update () {
if(player!=null)
		{
        navAgent.destination = player.transform.position;
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance <= stopDistance)
        {
            navAgent.isStopped = true;
        }
        else
        {
            navAgent.isStopped = false;
        }
		
        if(distance <= level)
        {
            Destroy(player);
        }
        
        
        if (isHit == true) 
        {
            
            gameObject.GetComponent<Animator> ().CrossFade("Z_FallingBack", 0f);
            Invoke("corpse",2f); 
            
        } 

        }
        if(player==null)
		{
			Application.LoadLevelAsync(loadName);
		}
    }
    void corpse()
    {
        Destroy(this.gameObject);
    }
}















