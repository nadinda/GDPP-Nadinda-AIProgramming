using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private BaseState _currentState;
    public PatrolState PatrolState = new PatrolState();
    public ChaseState ChaseState = new ChaseState();
    public RetreatState RetreatState = new RetreatState();
	public List<Transform> Waypoints = new List<Transform>();
    public float ChaseDistance;
    public Player Player;
    [HideInInspector] public NavMeshAgent NavMeshAgent;
	[HideInInspector] public Animator Animator;

	private void Start()
	{
    	if(Player != null)
    	{
        	Player.OnPowerUpStart += StartRetreating;
        	Player.OnPowerUpStop += StopRetreating;
    	}
	}
 
    private void Awake()
    {
        _currentState = PatrolState;
        _currentState.EnterState(this);
        NavMeshAgent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();
    }
 
    private void Update()
    {
        if(_currentState != null)
        {
            _currentState.UpdateState(this);
        }
    }

	public void SwitchState(BaseState state)
    {
        _currentState.ExitState(this);
        _currentState = state;
        _currentState.EnterState(this);
    }

	public void UpdateState(Enemy enemy)
	{
    	if (enemy.Player != null)
    	{
        	enemy.NavMeshAgent.destination = enemy.transform.position - enemy.Player.transform.position;
    	}
	}

	private void StartRetreating()
	{
    	SwitchState(RetreatState);
	}
 
	private void StopRetreating()
	{
    	SwitchState(PatrolState);
	}
}