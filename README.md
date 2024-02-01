# KAL_XFS4IoT_SP-Dev-Samples
KAL’s XFS4IoT SP-Dev is an open source implementation of the revolutionary new XFS version 4 global standard. It is ready for the IoT era and paves the way for a cloud-based, secure, OS-agnostic ATM industry.

This repo contains sample code written using the KAL XFS4IoT SP-Dev Framework available here: https://github.com/KAL-ATM-Software/KAL_XFS4IoT_SP-Dev

Find out more about this exciting new project and how you can get involved in shaping the ground-breaking XFS4IoT SP-Dev framework by contacting us @ xfs4iot_sp-dev_info@kal.com

## Building the sample simulator

1. Clone KAL_XFS4IoT_SP-Dev-Samples repository from https://github.com/KAL-ATM-Software/KAL_XFS4IoT_SP-Dev-Samples.
2. Install Visual Studio 2022 and .Net8 SDK or runtime.
3. Make sure online nuget package source is configured. Menu->Tools->NuGet Package Manager->Package Manager Settings->Package Sources has online location https://api.nuget.org/v3/index.json. For offline environment, all XFS4IoT framework NuGet packages need to be downloaded first and point offline location where the downloaded packages are stored locally in the package manager settings. The nuget packages are availble from KAL_XFS4IoT_SP-Dev repositry. https://github.com/KAL-ATM-Software/KAL_XFS4IoT_SP-Dev/releases
4. Open the solution `Devices/SPs.sln` in Visual Studio 2022.
5. Select Solution SPs in the solution explorer and execute Clean Solution.
6. Select Solution SPs in the solution explorer and execute Rebuild Solution.
7. Build complete both projects without errors.
8. Binaries are created under `Devices/bin/Debug/net8.0-windows7.0` or `Release/net8.0-windows7.0`.
9. The SP executable **XFS4IoT.SP.ServerHostSample.exe** is created. The executable has dependencies with other DLLs created in the same folder.
10. The default IP address is the local host 127.0.0.0. If the SP and client application run on the same machine, no configuration changes are required. If the IP address needs to be changed it can be done so remotely with the client application from different machine as follows: 
    1. Open the configuration file of the SP, ***XFS4IoT.SP.ServerHostSample.dll.config***, in the test file editor, for example VS Code.
    2. Change value of the `ServerAddress` key.  
        `<add key="ServerAddressUri" value="**http://xxx.xxx.xxx.xxx**" />`
11. Run XFS4IoT.SP.ServerHostSample.exe.

## Building the sample client application

1. Clone KAL_XFS4IoT_SP-Dev-Samples repository from https://github.com/KAL-ATM-Software/KAL_XFS4IoT_SP-Dev-Samples.
2. Install Visual Studio 2022 and .Net8 SDK or runtime.
3. Make sure online nuget package source is configured. Menu->Tools->NuGet Package Manager->Package Manager Settings->Package Sources has online location https://api.nuget.org/v3/index.json. For offline environment, all XFS4IoT framework NuGet packages need to be downloaded first and point offline location where the downloaded packages are stored locally in the package manager settings. The nuget packages are availble from KAL_XFS4IoT_SP-Dev repositry. https://github.com/KAL-ATM-Software/KAL_XFS4IoT_SP-Dev/releases
4. Open the solution `ClientTestApp/ClientTestApp.sln` in Visual Studio 2022.
5. Select ClientTestApp in the solution explorer and execute Clean Solution.
6. Select ClientTestApp in the solution explorer and execute Rebuild Solution.
7. Build complete both projects without errors.
8. Binaries are created under `ClientTestApp/bin/Debug/net8.0-windows` or `Release/net8.0-windows`.
9. The SP executable **TestClientForms.exe** is created. The executable has dependencies with other DLLs created in the same folder.
10. Run **TestClientForms.exe**
11. The default IP address is the local host 127.0.0.1. If the SP and client application run on the same machine, no configuration changes are required.  
If the SP and client application run on the different machines, change the Service URL on the top left of GUI. i.e. **ws://xxx.xxx.xxx.xxx** where the SP is running.
12. Click the Service Discovery button.  
The CardReader URL is displayed if the connection is established with the SP.
13. The test application can communicate with the CardReader SP.

