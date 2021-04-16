import tensorflow as tf
import numpy as np
from tensorflow import keras


def run():
    class MyCallback(tf.keras.callbacks.Callback):
        def on_epoch_end(self, epoch, logs=None):
            if logs.get('accuracy') >= 0.998:
                print("\nReached 99.8% accuracy so cancelling training!")
                self.model.stop_training = True

    callback = MyCallback()
    # YOUR CODE ENDS HERE

    mnist = tf.keras.datasets.mnist
    (training_images, training_labels), (test_images, test_labels) = mnist.load_data()
    # YOUR CODE STARTS HERE
    training_images = training_images.reshape(60000, 28, 28, 1)
    training_images = training_images / 255.0
    test_images = test_images / 255.0
    # YOUR CODE ENDS HERE

    model = tf.keras.models.Sequential([
        # YOUR CODE STARTS HERE
        tf.keras.layers.Conv2D(32, (3, 3), activation='relu', input_shape=(28, 28, 1)),
        tf.keras.layers.MaxPooling2D(2, 2),
        tf.keras.layers.Flatten(),
        tf.keras.layers.Dense(512, activation=tf.nn.relu),
        tf.keras.layers.Dense(10, activation=tf.nn.softmax)
        # YOUR CODE ENDS HERE
    ])

    model.compile(optimizer='adam', loss='sparse_categorical_crossentropy', metrics=['accuracy'])
    # model fitting
    history = model.fit(
        # YOUR CODE STARTS HERE
        training_images, training_labels, epochs=20, callbacks=[callback]
        # YOUR CODE ENDS HERE
    )


# class MyCallback(tf.keras.callbacks.Callback):
#     def on_epoch_end(self, epoch, logs=None):
#         if logs.get('accuracy') > 0.99:
#             print("\nReached 99% accuracy so cancelling training!")
#             self.model.stop_training = True
