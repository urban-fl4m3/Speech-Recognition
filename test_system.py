import tensorflow as tf
import numpy as np


def function(x):
    return 4 * x * x + 3


def run():
    model = tf.keras.Sequential([
        tf.keras.layers.Dense(512, activation=tf.nn.relu),
        tf.keras.layers.Dense(128, activation=tf.nn.relu),
        tf.keras.layers.Dense(1)])

    model.compile(optimizer='adam', loss='mean_squared_error')

    a1 = -12.0
    a2 = 5.0
    a3 = 1.0
    a4 = 10.0
    a5 = 3.0
    a6 = 8.0
    a7 = 23.0

    xs = np.array([a1, a2, a7, a4, a5, a6, a3], dtype=float)
    ys = np.array([function(a1), function(a2), function(a7), function(a4), function(a5), function(a6), function(a3)],
                  dtype=float)

    model.fit(xs, ys, epochs=10000)

    print(model.predict([7.0]))
