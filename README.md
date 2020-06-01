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

Surprise, surprise! I added Decorator Nodes the day after I last updated the README.

My next plan is to change how the nodes return statuses so they can return a status of RUNNING instead of just SUCCESS or FAILURE. After that is the Node Graph Editor! Very exciting.

### Useful resources
- [Gamasutra Article](https://www.gamasutra.com/blogs/ChrisSimpson/20140717/221339/Behavior_trees_for_AI_How_they_work.php)
- [BT Wikipedia Article](https://en.wikipedia.org/wiki/Behavior_tree_(artificial_intelligence,_robotics_and_control))