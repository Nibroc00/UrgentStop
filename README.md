# Urgent Stop

## Project Overview
The goal of this project is to construct an algorithm which is capable of stopping an autonomous vehicle. The algorithm should be capable of stopping the vehicle in an optimal manner; for example, it should come to a smooth stop when able or come to a quick stop in an emergency. Here is the *zombi* robot for which this will be developed:

![zombi](docs/img/zombi.jpg)

Ideally, we would like this work to be generally applicable, not just to zombi.

## Unity
To remove the need for the physical vehicle, we will simulate stopping the vehicle within Unity. To get started with Unity, download [Unity Hub](https://store.unity.com/download).

To manage the massive files that inevitably come alongside Unity, we will be managing collaboration on the project through [USU Box](https://usu.box.com/s/xtl9fxxkhctdc1rjtejiln4rb5vxd3r6).

## Resources

* [Unity Beginner Tutorial](https://learn.unity.com/project/beginner-gameplay-scripting)
* [Unity Physics Tutorial](https://learn.unity.com/project/catapult-physics-forces-and-energy)
* [Resource Spreadsheet](https://docs.google.com/spreadsheets/d/1I5JpQnZM30WNyA38qt06HCm65Qe8D7nMhxwOaNdKe6A/edit?usp=sharing)


## User Manual

### 1. Necessary Software Installation
#### 1.1 Download Unity
Go to [https://unity.com/download](https://unity.com/download) which is the Unity downloads page. Scroll down slightly to the title that says Create with Unity in three steps. Then in the section labeled, *1. Download the Unity Hub*, click on the blue text that says *Download for Windows*.

![Download for Windows](docs/img/download-unity.jpg)

When the download is complete, select it from the downloads menu at the bottom of your screen.

![Select executable from downloads](docs/img/unity-exe.jpg)

You will then see a pop-up that asks if you want to *allow this app to make changes to your device*. Select *yes*.

You will then see a pop-up with a licensing agreement. Select *I Agree*. 

![Agree to terms of service](docs/img/terms-of-service.jpg)

You can then select the location for the installation. If you desire, you can change the location. Otherwise, select *install*.

![Click Install](docs/img/save-location.jpg)

You will see your final pop-up. Make sure that the *Run Unity Hub* box is checked. Then press *Finish*.

![Click Finish](docs/img/run-unity.jpg)

A pop up will then appear. Click *Skip Installation* in the bottom right corner.

![Skip installation](docs/img/skip-installation.jpg)

Select *installs* from the menu on the left.

![Click Installs](docs/img/select-installs.jpg)

Then click the blue button that says *Install Editor*.

![Click Install Editor](docs/img/install-editor.jpg)

Select the *Archive* tab.

![Click Archive](docs/img/archive.jpg)

Click on the blue text that says *download archive*.

![Click Download Archive](docs/img/download-archive.jpg)

You will be taken to the Unity downloads archive. Scroll down and select the tab for *Unity 2020.x*.

![Click Unity 2020.x](docs/img/unity-2020.jpg)

Then scroll down to Unity 2020.3.29f1. Click the corresponding green button that says *Unity Hub*.

![Click the appropriate Unity Hub button](docs/img/unity-hub.jpg)

The installation will then begin and when it is complete you will see a popup that asks if you want to *allow this app to make changes to your device*. Select *yes*.

#### 1.2 Connect to the USU VPN
If you are not connected to the USU network, you will need to connect to the USU VPN. Go to [https://usu.service-now.com/aggies?id=kb_article_view&sysparm_article=KB0011477&sys_kb_id=fb3eb5d2b8834100bd5c10e091b7dbf3&spa=1](https://usu.service-now.com/aggies?id=kb_article_view&sysparm_article=KB0011477&sys_kb_id=fb3eb5d2b8834100bd5c10e091b7dbf3&spa=1) and follow the installation instructions for the VPN.

#### 1.3 Install Git LFS
Git lfs uses a separate server for easier managing of large files. 
Visit [https://git-lfs.github.io/](https://git-lfs.github.io/) to download. On Linux, you likely just need to install the `git-lfs` package from your distro's repository.

![Download Git LFS](docs/img/gitlfs.jpg)

In the windows search bar, search for the command prompt. Click on the Command Prompt app to open it.

![Open a Command Prompt](docs/img/open-cmd-prompt.jpg)

Type in `git lfs install` and press enter. 

![Git LFS Initialized](docs/img/lfs-initialized.png)

You know this is installed properly if you type in `git lfs version` then press enter and are shown the version rather than an error message.

![See LFS version number](docs/img/lfs-version.png)


### 2. Accessing The Project
#### 2.1 Cloning the Repository
Make sure you are connected to the USU VPN. 

Open the command prompt. To clone the project on your desktop type in `cd Desktop` and press enter, otherwise, navigate to the location where you would like to clone the project. Then type `git clone mater@129.123.24.8:urgentstop.git UrgentStopSimulation` and press enter. Wait for the cloning process to finish.

![Clone the project](docs/img/clone.png)

You will then be prompted to give a password. Type in *spot* and then press enter. 

#### 2.2 Opening The Project In Unity
Return to the Unity hub and select the *Projects* tab from the lefthand menu.

![Click Projects](docs/img/projects.jpg)

Click the arrow next to the open button. Then click on the option *Add Project From Disk*.

![Click the dropdown on Open](docs/img/add-project.jpg)

![Click Add project from disk](docs/img/add-from-disk.jpg)

Navigate to the directory where you cloned the project. If you followed the steps shown in previous steps, the directory is on the desktop and is named *UrgentStopSimulation*. Select the folder and then press the *Add Project* button.

![Select your Urgent Stop project folder](docs/img/add-project-file-explorer.jpg)

Double click on the project in the Unity hub to open it in the Unity editor. It will take some time to load, but the project will then open in Unity.

![Click your project from the projects list](docs/img/open-in-unity.jpg)

### 3. Running The Simulation In Unity
#### Opening the Scene
In the Unity Editor there is a list of assets in the bottom left corner, select *Scenes*.

![Select scenes](docs/img/select-scenes.jpg)

Double click on *Scene*.

![Double click Scene](docs/img/scene.jpg)

Then click the play button arrow at the top of the screen to start the simulation.

![Click the play button](docs/img/click-play.jpg)

#### 3.2 Changing The Simulation Variables And Running The Simulation
Select the parameters for the simulation:
* Car mass: The mass of the vehicle (USU's Zombi)
* Terrain: The type of ground desired to test stopping
* Stopping Distance: The distance in meters the obstacle will be from the vehicle

Then press the *Start Simulation* button.

![Click Start Simulation](docs/img/start-sim-button.png)

Initially, the zombi will be getting up to top speed. Note that the obstacle will not appear in the simulation until the vehicle has reached top speed (about 4.5 m/s). The HUD displays the zombi current speed, the mass of the vehicle, the terrain friction, and the stopping distance to the obstacle.

![Grass Terrain](docs/img/grass-terrain.png)

Once top speed is reached, the distance to obstacle countdown will begin.

![Count Down Started](docs/img/countdown-start.png)

And the zombi will come to a stop.

![Zombi Stopped](docs/img/stopped-before-obstacle.png)

### 4. Executable
#### 4.1 Accessing The Executable
Navigate to where you cloned the project on your computer.

Unzip the contents of the zipped *urgentstop build* folder.

If needed, in the newly unzipped folder, open the directory named *urgentstop build*.

Double click the executable file *UrgentStop*.

#### 4.2 Running The Executable
Select the parameters for the simulation:
* Car mass: The mass of the vehicle (USU's Zombi)
* Terrain: The type of ground desired to test stopping
* Stopping Distance: The distance in meters the obstacle will be from the vehicle

Press the *Start Simulation* button to run the simulation.

Initially, the zombi will be getting up to top speed. Note that the obstacle will not appear in the simulation until the vehicle has reached top speed (about 4.5 m/s). The HUD displays the zombi current speed, the mass of the vehicle, the terrain friction, and the stopping distance to the obstacle.

Once top speed is reached, the distance to obstacle countdown will begin, and zombi will slow down until it stops.

From here, you can either press the restart button in the HUD to reset the simulation or press the escape key on your keyboard to exit the application.