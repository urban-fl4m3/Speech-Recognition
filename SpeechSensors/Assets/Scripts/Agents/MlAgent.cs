using System.Collections.Generic;
using DefaultNamespace;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;

namespace Agents
{
    public class MlAgent : Agent
    {
        public Vector3 DefaultPosition = Vector3.zero;
        
        private readonly List<float> _observations = new List<float>();
        
        public void AddObservations(IEnumerable<float> observations)
        {
            _observations.Clear();
            _observations.AddRange(observations);
        }

        private float _xBondLeft;
        private float _xBondRight;
        private float _zBondBottom;
        private float _zBondTop;
        
        public void AddBonds(float xBondLeft, float xBondRight, float zBondBottom, float zBondTop)
        {
            _xBondLeft = xBondLeft;
            _xBondRight = xBondRight;
            _zBondBottom = zBondBottom;
            _zBondTop = zBondTop;
        }
        
        public override void OnEpisodeBegin()
        {
            transform.position = DefaultPosition;
        }

        public override void CollectObservations(VectorSensor sensor)
        {
            // Debug.Log(_observations.Count);
            foreach (var observation in _observations)
            {
                sensor.AddObservation(observation);
            }
        }
        

        public override void OnActionReceived(float[] vectorAction)
        {
            var moveX = vectorAction[0] * 0.5f + 0.5f;
            var moveZ = vectorAction[1] * 0.5f + 0.5f;

            moveX = moveX * (_xBondRight - _xBondLeft) + _xBondLeft;
            moveZ = moveZ * (_zBondTop - _zBondBottom) + _zBondBottom;
            
            transform.position = new Vector3(moveX, 0, moveZ);
        }

        public void AddRewardFromScene(float amount)
        {
            SetReward(amount);    
        }
        
        public void Complete()
        {
            //Debug.Log("COMPLETE");
            
            SetReward(20f);
            EndEpisode();
            UI.Instance.AddComplete();
        }

        public void Fail()
        {
            //Debug.Log("FAIL");
            SetReward(-20f);
            EndEpisode();
            UI.Instance.AddFail();
        }
    }
}