# Cross platform example repository
## Apps
The idea is that on the App side you implement the platform specific needs once, with minimal code changes once done. And on the CrossPlatform project make all the more complex UI logic changes.
## Bridge pattern
The bridge pattern is used to separate the platform specific implementation behind interfaces. Normally the brigde pattern can have multiple abstractions, here I only have one, 
so I have not created any derived abstractions.
