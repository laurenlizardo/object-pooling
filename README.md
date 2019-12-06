# generic-object-pooling
A generic object pooling design pattern applicable to Unity game development.

## Overview
This repo is a generic implementation for object pooling. It involves three components:
* a generic object pool class that takes in a generic type and contains object pooling methods
* a class deriving from the generic object pool that handles the implementation
* an object to be used as the generic type/object pool element
A fourth component also exists in this example, but its purpose is purely for input handling.