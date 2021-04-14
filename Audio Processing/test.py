import tensorflow as tf

print('')
print(tf.__version__)
print('')

import keras as k

l0 = k.layers.Dense(units=1)
model = k.Sequential(l0)

