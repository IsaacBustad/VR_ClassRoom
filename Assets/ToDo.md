# VR Classroom To do and Dev Log

## Placer conversion

- [x] inherit from PlacableItemPlacer to NetPlacableItemPlacer
- [x] Edit a copy of the placer gun
  - [x] Edit the placer gun to snap to the player right hand
  - [x] Edit to use NetPlacableItemPlacer
- [x] Test that new placer places for host

## Step 2: Spawn Objects on the Network

- [x] Host should be able to place networked objects using PlacableItemPlacer 
- [ ] Allow host to permit user to place items in the room
- [ ] Client should be able to place items using PlacableItemPlacer 
  - [ ] User the NetworkPermissionsMannager to enable user to place items
  - [ ] Spawan the item using the command on the spawn bridge
- [x] Creat new NetPlacableItems
- [x] Disable placer on Guest Can Edit Turned off
- [x] Enable placer on Guest Can Edit Turned on

## Step 3: Item Remover Conversion

- [x] Create a NetPlacableItemRemover
  - [x] Inherit  PlacableItemRemover to NetPlacableItemRemover
- [x] Allow host to remove network items
- [ ] Allow host to toggel guest permission to remove items
- [ ] Allow guest to remove items
  - [ ] Guest can only remove items when permitted
  - [ ] Guest can remove networked Items from the scene
- [ ] Disable Remover on Guest Can Edit Turned off
- [ ] Enable Remover on Guest Can Edit Turned on

## Step 4: Canvas For Selection

- [x] Allow the host to permit or deney guest to place items
- [x] Allow the host to permit or deney guest to place items
- [ ] Allow host and guest to select what Item to place 
- [x] Allow host and guest to record a session

## Step 5: Grab and Interact with Items in XR

- [x] Allow the host and guest to interact with the placed items
- [ ] Make sure that transforms and states are updated

## Step 5: Memento

- [ ] Create Networked Memento system
- [ ] Add permission for recording
- [ ] Add Permission for replay
- [ ] Allow host to record the networked room
- [ ] Allow client to record the the networked room
- [ ] Optional allow networked replay 
  - [ ] Allow host to replay
  - [ ] Allow guest to replay

## Optional features

- [ ] Rebuild local room building functions
  - [ ] Local Placer Update
  - [ ] Local Player Construction

## On Location Development Tasks

- [ ] UI compleate
- [x] Grab and interact with objects
- [ ] Begin Memento Conversion
