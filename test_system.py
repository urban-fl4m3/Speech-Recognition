import tensorflow as tf
import numpy as np


def function(x):
    return 4 * x * x + 3


def run():
    model = tf.keras.Sequential([
        tf.keras.layers.Dense(512, activation=tf.nn.relu),
        tf.keras.layers.Dense(128, activation=tf.nn.relu),
        tf.keras.layers.Dense(3)])

    model.compile(optimizer='adam', loss='mean_squared_error')

    a1 = -12.0
    a2 = 5.0
    a3 = 1.0
    a4 = 10.0
    a5 = 3.0
    a6 = 8.0
    a7 = 23.0

    time1_test = np.array([3.62, 7.92, 7.14, 10.04, 3.1], dtype=float)
    time1_ans = [5.85, 1.09, 7.57]

    time2_test = np.array([3.62, 7.92, 7.14, 10.04, 3.1], dtype=float)
    time2_ans = [5.85, 1.09, 7.57]

    time3_test = np.array([3.62, 7.92, 7.14, 10.04, 3.1], dtype=float)
    time3_ans = [5.85, 1.09, 7.57]

    time4_test = np.array([3.62, 7.92, 7.14, 10.04, 3.1], dtype=float)
    time4_ans = [5.85, 1.09, 7.57]

    time5_test = np.array([3.62, 7.92, 7.14, 10.04, 3.1], dtype=float)
    time5_ans = [5.85, 1.09, 7.57]

    time6_test = np.array([3.62, 7.92, 7.14, 10.04, 3.1], dtype=float)
    time6_ans = [5.85, 1.09, 7.57]

    time7_test = np.array([3.62, 7.92, 7.14, 10.04, 3.1], dtype=float)
    time7_ans = [5.85, 1.09, 7.57]

    xs = np.array([time1_test, time2_test, time3_test, time4_test, time5_test, time6_test, time7_test])
    ys = np.array([time1_ans, time2_ans, time3_ans, time4_ans, time5_ans, time6_ans, time7_ans])

    model.fit(xs, ys, epochs=1000)

    print(model.predict(time1_test))
