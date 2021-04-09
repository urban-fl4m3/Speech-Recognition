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
        var b = tf.constant(3);
        var c = tf.constant(5);

        var mean = tf.reduce_mean(new[] {a, b, c});
        var sum = tf.reduce_sum(new[] {a, b, c});
        
        Debug.Log($"Mean: {mean}");
        Debug.Log($"Sum: {sum}");
    }
}
