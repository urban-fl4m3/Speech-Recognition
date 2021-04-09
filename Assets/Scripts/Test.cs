using UnityEngine;
using Tensorflow;
using static Tensorflow.Binding;
using NumSharp;
using System.IO;


public class Test : MonoBehaviour
{
    void Start()
    {
        var a = tf.constant(2);
    }
}
