# Molten's Behaviour Tree Creator
Hello and welcome to the repository of Molten's Behaviour Tree Creator!
This is a currently in development Unity asset that is designed to facilitate the easy development of complex A.I behaviour.

I have a devlog in progress to show my research and development progress of the asset too.

## Overview
As I mentioned, this asset is planned to be a free asset package for Unity 2019.2.17f and higher.
I will also be creating documentation along the way to aid the integration of the asset package.

### Package Features/Contents
- [x] Composite Nodes
- [x] Leaf Nodes
- [x] Decorator Nodes
- [ ] Visual Node Graph Editor
- [ ] Documentation

### Current Status
The current status of the project as of 1/06/2020;
Behaviour Trees can be made quite easily by creating a BehaviourTree object in a script that is placed on an A.I Agent. The trees can currently consist of Composite Nodes (Selector/Sequence), Leaf Nodes and Decorator Nodes (Repeater, Retry, Inverter, Succeeder, Failer), resulting in some relatively complex A.I behaviour.

The last update altered the return type of all nodes to now return SUCCESS, FAILURE or RUNNING. SUCCESS and FAILURE work the same as the true/false bool return of the previous version, however returning RUNNING will stop the behaviour tree on the current node.
This means things like moving to a new position can return RUNNING when they're on the move. This means no further processing will be done on nodes that come after the Move node, but will still allow nodes that come before to interrupt the movement.

My next plan is to add the Node Graph Editor! Very exciting. After that I'll just just work on some documentation and publish!

### Useful resources
- [Gamasutra Article](https://www.gamasutra.com/blogs/ChrisSimpson/20140717/221339/Behavior_trees_for_AI_How_they_work.php)
- [BT Wikipedia Article](https://en.wikipedia.org/wiki/Behavior_tree_(artificial_intelligence,_robotics_and_control))