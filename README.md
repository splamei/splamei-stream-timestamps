![Splamei Stream Timestamps - Banner](https://raw.githubusercontent.com/splamei/splamei-stream-timestamps/refs/heads/main/Images/Banner.png)


![Checks](https://img.shields.io/github/check-runs/splamei/splamei-stream-timestamps/main)
[![CodeFactor](https://www.codefactor.io/repository/github/splamei/splamei-stream-timestamps/badge)](https://www.codefactor.io/repository/github/splamei/splamei-stream-timestamps)
![Issues](https://img.shields.io/github/issues/splamei/splamei-stream-timestamps)
![License](https://img.shields.io/github/license/splamei/splamei-stream-timestamps)
![Repo Size](https://img.shields.io/github/repo-size/splamei/splamei-stream-timestamps)

![YouTube Subs](https://img.shields.io/youtube/channel/subscribers/UCyJR4GlzoshPLoj3r1Jy7Fg)
![Twitter Follow](https://img.shields.io/twitter/follow/splamei)
![Bluesky Followers](https://img.shields.io/bluesky/followers/splamei.vtubers.social)
# Splamei Stream Timestamps
A simple basic app for saving timestamps for live streamers and content creators instead of manually searching videos / VODs for clips or creating time limited highlights and using RAM.

## Screenshots

![Main UI](https://raw.githubusercontent.com/splamei/splamei-stream-timestamps/refs/heads/main/Images/Main.png)
![Start delay](https://raw.githubusercontent.com/splamei/splamei-stream-timestamps/refs/heads/main/Images/Start%20Delay.png)
![Recording timestamps](https://raw.githubusercontent.com/splamei/splamei-stream-timestamps/refs/heads/main/Images/Recorded%20Stamp.png)
![Stopped recording](https://raw.githubusercontent.com/splamei/splamei-stream-timestamps/refs/heads/main/Images/Stopped%20record.png)
![About dialog](https://raw.githubusercontent.com/splamei/splamei-stream-timestamps/refs/heads/main/Images/About.png)

## Features

 - Key binding support
 - Small and lightweight
   - Low CPU and RAM usage
 - Easy to run and use
 - Adjustable starting delay

## Why use this?

This app is made to make is easy to record timestamps for future use while recording when you don't have time to manually type/write the time regardless of the hardware used. It's simple and lightweight so almost any hardware that can run Windows 10+ should be able to run it.

You may want to use the app if you are a:
- Content creator
- Streamer
- Journalist
- (Studio) Camera Operator
- Video recorder

## Compatibility
- Windows 10 or later
  - You may be able to run the app on older Windows installs
- .NET Framework 4.7.2 (pre-installed on modern Windows)
- A keyboard (better yet, a mouse too)

## Installation

1. Download the latest release from the [release page](https://github.com/splamei/splamei-stream-timestamps/releases)
2. Open the downloaded file
	- You'll likely get a warning from Windows SmartScreen about the app due to being unknown. Don't worry, this is normal. If you're concerned about the app, you should use an Anti-Virus to scan the app
3. The app should now be running

## Using the app

### Starting a recording

1. Set the delay for starting the recording (`Stream delay offset` - Top left). You may want to set this to 3 seconds to start your recording on-time
2. Set the key binding to use to record times (`Keybinding to record` - Top right). You can set this to be key F1 to F24 (F13-F24 is not on most keyboard), use Numpad 0 or disable key bindings (None)
   - You won't be able to change your key bindings while recording meaning you will have to pause the recording to change it.
4. Press 'Start'

> [!IMPORTANT]  
>  Pressing start will clear all timestamps you have saved and they won't be recoverable

### Actions while running

- Recording a time - Press the 'Record Time' button or press the key set to record a time
- Pausing a recording - Press the 'Pause' button
  - When paused, you can change the key binding used to record the time
- Unpausing a recording - Press the 'Start' button when paused
- Stopping a recording - Press 'Stop' while recording (not paused)
- Clearing timestamps - Press 'Clear' after a recording was stopped

## Building from source

This section presumes you have the .NET (Framework) and Windows SDKs, Git installed and a basic knowledge of the apps and how to use them.

> [!NOTE]  
> When building from source, it will lack the digital signature used by official builds. Please be careful of that

### Visual Studio (Recommended)

1. Clone the repo in Visual Studio by pressing 'Clone a repository' and pasting the repo's URL (`https://github.com/splamei/splamei-stream-timestamps.git`)
3. Build the code by pressing `Build > Build Splamei Stream Timestamps` or pressing CTRL + B
4. The build files should be located in `<Repo directory>\bin\Debug\Splamei Stream Timestamps.exe`

### MSBuild

1. Clone the repo by running `git clone https://github.com/splamei/splamei-stream-timestamps.git` in the target directory
2. Change into the directory via `cd splamei-stream-timestamps`
3. Build the project using `msbuild  "Splamei Stream Timestamps.sln"  /p:Configuration=Release  /p:Platform="Any CPU"  /p:RestorePackages=false  /m  /verbosity:minimal`
4. The build files should be located in `<Repo directory>\bin\Debug\Splamei Stream Timestamps.exe`

## Contributing

Any support to this repo would help a lot. You could help by:
 - Reporting issues / feature requests on the [issue page](https://github.com/splamei/splamei-stream-timestamps/issues)
 - Making forks of the repo
 - Making pull request to add code or fix bugs
 - Staring or watching the repo
 - Sharing the repo

## Socials

[YouTube](https://youtube.com/@splamei)
[Twitter](https://twitter.com/splamei)
[Bluesky](https://bsky.app/profile/splamei.vtubers.social)
[Discord](https://discord.gg/g2KTP5X9At)

## License

All code in this repo is licensed under the MIT Licence unless otherwise stated.

All third-party licenses are under their respective license.

## Built with ❤️ in Visual Studio