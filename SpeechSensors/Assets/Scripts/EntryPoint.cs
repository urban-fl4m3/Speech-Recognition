using System;
using Agents;
using Components;
using UnityEngine;
using Random = UnityEngine.Random;

public class EntryPoint : MonoBehaviour
{
    public static bool EnableDebugMode => true;
    
    [SerializeField] private bool _enableDebugMod;
    [SerializeField] private GameObject _roomObject;
    [SerializeField] private HumanComponent _humanComponent;
    [SerializeField] private MlAgent _mlAgent;
    [SerializeField] private float _rewardStep;

    [SerializeField] private SensorComponent[] _sensorComponents;
    [SerializeField] private MicrophoneComponent[] _microphoneComponents;
    
    private Room _room;
    private Human _human;

    private float _timeToEndRound = 0.0f;
    private float _lastDistance;
    
    public float ElapsedTimeFromRoundStart;
    
    private void Start()
    {
        
        var x = transform.position.x;
        var z = transform.position.z;
        
        _room = new Room(_roomObject, _sensorComponents, _microphoneComponents, _mlAgent, this);
        _room.System.Agent.DefaultPosition = transform.position;
        _room.System.Agent.AddBonds(x - 13, x + 13, z - 14, z + 14);
        _human = new Human(_humanComponent);
        
        BeginRound();
        
        Debug.Log(_room.ToString());

    }

    private void BeginRound()
    {
        ResetTime();
        
        var x = transform.position.x;
        var z = transform.position.z;
        
        var xRnd = Random.Range(x -13, x + 13);
        var zRnd = Random.Range(z -14, z + 14);
        _human.ChangePosition(new Vector3(xRnd, _human.Position.y, zRnd));
        
        _room.System.ReactAllMics(_human.SpreadSpeed, _human.Position);
        //_human.PushSignal();

        _lastDistance = Vector3.Distance(_human.Position, _room.System.Agent.transform.position);
    }

    private void ResetTime()
    {
        ElapsedTimeFromRoundStart = 0.0f;
        _timeToEndRound = 0.0f;
        _timeSinceLastReward = 0.0f;
    }

    private void EndRound()
    {
        BeginRound();
    }

    private float _timeSinceLastReward;

    private void Update()
    {
        _timeToEndRound += Time.deltaTime;
        ElapsedTimeFromRoundStart = _timeToEndRound;

        var dist = Vector3.Distance(_room.System.Agent.transform.position, _human.Position);
        if (Vector3.Distance(_room.System.Agent.transform.position, _human.Position) <= 2)
        {
            _room.System.Agent.Complete();
            EndRound();
        }

        _timeSinceLastReward = Time.time;

        //Debug.Log($"REWARD FROM SCENE: {reward} / Distance: {dist}");
        _room.System.Agent.AddRewardFromScene((1 - dist/12) * 10);


        if (_timeToEndRound >= 1)
        {
            _room.System.Agent.Fail();
            EndRound();
        }
    }
}
