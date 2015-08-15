# ImageBasedMocap

GPL licensed Image based motion capture application. Use as you wish internally, please contribute back to the project.

Use automated techniques or manual rotoscoping to construction animation data from camera inputs.

Objectives
- Part-based automatic generation
- Hull construction and median axis automatic generation
- Manually fit the skeleton to the images
    - Explicit rotoscoping
    - Automatic generation cleanup
- Easily implement new algorithms for skeleton fitting
- Easily implement new algorithms for mixing the fitted skeletons of multiple viewpoints

Long Term Objectives
- Fast calibration (calibrate all cameras at once, with a maglight)
- Motion library reconstruction
- Voice commands for single "user is actor" situations
- Prettier UI

## The Process

### Calibration

IBM first requires that you configure your recording devices. DirectShow devices (USB typically) and IP cameras are supported. IP camera support is largely for the purpose of using mobile devices as capture devices on a LAN.

The cameras must be calibrated for:
- Lens correction, as long as you do not move the cameras you may reuse lens calibration from saved files
- Spacial relationship, as long as you do not move the cameras you may reuse this calibration as well
- Background removal, should be recalibrated before each session - seeds the background remover

Calibration features:
- Initial Delay (seconds), how long to wait before starting calibration (e.g. single operator)
- Repeat Delay (seconds), how long to wait before starting the calibration frame
- Calibration shots, how many images to capture of the calibration pattern

### Recording

The video must be recorded. Framerate is limited to the lowest framerate of any device. The duration of the take may be specified.

Recording features:
- Delay (seconds), time before starting recording
- Duration (seconds), time to record for (<= 0 for until manually stopped)

The frames are written into a video as a strip.

### Processing

In order to process a video a skeleton must be loaded. Skeleton loading is the responsibility of plugins. The skeleton must then be mapped to the limited internal skeleton if using automatic tracking.

Rotoscoping has access to any selection of bones.

## Plugins

IBM uses a plugin library that defines the Skeleton and animation data.

### BVH Plugin

Import of BVH skeletons and export of BVH animations

### FBX Plugin

Import of skeletons from FBX files and export of animation to FBX

### Urho3D Plugin

Import of skeletons from Urho3D model files and export animation to Urho3D animation files.
