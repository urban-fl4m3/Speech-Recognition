using System.Collections.Generic;
using NumSharp;
using Tensorflow;
using Tensorflow.Keras;
using Tensorflow.Keras.ArgsDefinition;
using Tensorflow.Keras.Layers;
using Tensorflow.Keras.Optimizers;
using UnityEngine;
using static Tensorflow.Binding;

public class Test : MonoBehaviour
{
    private void Start()
    {
        var array = new NDArray(new float[]
        {
            1, 2, 3
        });

        var labels = new NDArray(new float[]
        {
            Function(1), Function(2), Function(3)
        });

        var dataset = tf.data.Dataset.from_tensor_slices(array);
        var dataset2 = tf.data.Dataset.from_tensor_slices(labels);

        var l0 = new Dense(new DenseArgs {Units = 3});
        var model = KerasApi.keras.Sequential(new List<ILayer> { l0 });
        
        var losses = KerasApi.keras.losses.SparseCategoricalCrossentropy(from_logits: true);
        var optimizer = KerasApi.keras.optimizers.SGD(1e-6f);
        model.compile(losses, optimizer, new []{ "accuracy"});
        model.fit(dataset, dataset2, epochs: 100);
        
        Debug.Log($"Layer weight {l0.weights}");
    }

    private float Function(float x)
    {
        return 4 * x * x + 3;
    }
}
