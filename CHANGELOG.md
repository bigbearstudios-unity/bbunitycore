# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.0.1] - 2020-08-11
### Added

- Added Conversion namespace
- Added BBBehviour
- Added Utilities

## [0.0.2] - 2020-09-17
### Added

- Added CallbackHandler
- Added ArrayUtilities

## [0.0.3] - 2020-09-20
### Added

- Added EventSystem

## [0.1.0] - 2020-10-31
### Added

- Changed BBBehaviour to BaseBehaviour

## [0.2.0] - 2020-11-01
### Removed 

- Event System moved to BBUnity Events

## [0.3.0] - 2020-11-03
### Removed 

- Removed the ability for CallbackHandler to find Global Interfaces

### Added 

- Added protection if statement on the Process

### Edited

- Changed Call to Process on the CallbackHandler

## [1.0.0] - 2020-11-03

### Edited

- Changed CallbackHandler to BehaviourDelegate

## [1.2.0] - 2020-11-21

### Added

- Added GlobalBehaviourDelegate

## [1.2.1] - 2020-11-25

### Edited

- Fixed a bug in the Editor.asmdef so that it was actually included via the Unity Editor

## [1.3.0] - 2020-05-07

### Added

- Added Name property to BaseBehaviour
- Added Disabled property to BaseBehaviour
- Added Inactive property to BaseBehaviour
- Added WaitThen method to BaseBehaviour, allows a method to be called upon waiting a given amount of time
- Added Subcomponents, SubcomponentController and SubcomponentBehaviour
- Added SceneReference within the BBUnity.SceneManagement namespace

### Edited

- Upgraded BBUnity Test Support to 1.1.1


## [1.5.0] - 2020-11-05

### Removed

- Removed Services / Service
- Removed LoadableRefernce
- Removed ArrayUtilities
- Removed Entire Callback namespace
- Removed UnityExtensions

## [2.0.0] - N/A

### Edited

- Changed the name of 'BaseBehaviour' to 'BBMonoBehaviour'

### Removed 

- Removed BBUnity.Controllers, due to not adding much value

## [3.0.0] - 2024-07-15

### Removed

- .Conversion namespace. This has been moved to its own library which exposes the BBUnity.Conversion namespace
- .Validation namespace. This has been moved to its own library which exposes the BBUnity.Validation namespace

## [4.0.0] - 2024-08-13

- Removed large amount of extra functionality on BBMonoBehaviour
- Changed ActivateGameObject / DeactivateGameObject to Activate / Deactivate

## [4.0.0] - 2024-11-17

- Changed the Attributes namespace to BBUnity.EditorAttributes

