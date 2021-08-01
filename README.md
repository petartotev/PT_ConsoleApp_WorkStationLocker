# PT_ConsoleApp_WorkStationLocker

WorkStationLocker is a simple console application. It should just lock my office laptop every time I get away from the desk.

![Hasselhoff_Scrot](res/scrot/hasselhoff_wallpaper.jpg)

## General Information

I have spent 6 months in Bede Gaming Ltd. and during this period I have forgotten my laptop unlocked twice.
In my first week I got Hasselhoffed. 6 months later, during my probation interview - I got Azissed too (see images).
This means that once I get back after a short visit to the toilet or the conference room my wallpaper is changed with pictures of mens' bodies, barerly dressed...

So I decided to defend myself!

I installed an analogous ultrasonic sensor behind my desk, connected to a Raspberry Pi Zero W. 
Once the distance in front of it gets longer than a certain value (meaning I moved away from my desk) a message with header 'Lock + current datetime' would be sent to my email.

What this application would do is to 'listen' for such emails. If it was received in the last seconds a windows command would lock the laptop automatically.

## Technologies

- using OpenPop.Mime;
- using OpenPop.Pop3;
- using System.Net.Mail;

## Contents

### src
- WorkStationLocker.ConsoleApp - to be executed on the office laptop
- WorkStationLOcker.PythonApp - to be executed on the Raspberry Pi + ultrasonic sensor
- WorkStationLocker.sln 

### res
- hasselhoff_wallpaper.jpg
- azis_wallpaper.jpg

## ~ HAPPY END ~

![As-Is_Scrot](res/scrot/azis_wallpaper.jpg)
