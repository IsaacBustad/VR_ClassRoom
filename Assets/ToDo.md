# VR Classroom To do and Dev Log

## Step 1: Placer conversion

- [x] inherit from PlacableItemPlacer to NetPlacableItemPlacer
- [x] Edit a copy of the placer gun
  - [x] Edit the placer gun to snap to the player right hand
  - [x] Edit to use NetPlacableItemPlacer
- [x] Test that new placer places for host

## Step 2: Spawn Objects on the Network

- [x] Host should be able to place networked objects using PlacableItemPlacer 
- [ ] Hllow host to permit user to place items in the room
- [ ] Client should be able to place items using PlacableItemPlacer 
  - [ ] User the NetworkPermissionsMannager to enable user to place items
  - [ ] Spawan the item using the command on the spawn bridge
- [x] Creat new NetPlacableItems

## Step 3: Item Remover Conversion

- [ ] Create a NetPlacableItemRemover
  - [ ] Inherit  PlacableItemRemover to NetPlacableItemRemover
- [ ] Allow host to remove network items
- [ ] Allow host to toggel guest permission to remove items
- [ ] Allow guest to remove items
  - [ ] Guest can only remove items when permitted
  - [ ] Guest can remove networked Items from the scene

## Step 4: Memento

- [ ] Create Networked Memento system
- [ ] Add permission for recording
- [ ] Add Permission for replay
- [ ] Allow host to record the networked room
- [ ] Allow client to record the the networked room
- [ ] Optional allow networked replay 
  - [ ] Allow host to replay
  - [ ] Allow guest to replay
