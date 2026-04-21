
Overview
This project improves a basic lane-switching car prototype into a polished arcade-style experience inspired by Dashy Crashy.
Focus was on visuals, game feel, and performance.



Lighting

Lighting
Used two directional lights with culling masks
Environment lighting is baked for performance
Real-time lighting is used only for the car


 Car Enhancements

Car Enhancements
Updated car textures to match stylized look
Added left/right animations (controlled via script)
Implemented VFX for better feedback
Added a gradual speed increase through scripting


Camera & Feel
Smooth follow camera with damping (Cinemachine)
Dynamic FOV based on speed to enhance motion feel


Assets / Tools Used
Unity (URP / Mobile RP)
Cinemachine (camera system)
TextMeshPro (UI)
Built-in & custom textures/materials/Model 



Optimization Decisions
Switched to Mobile/URP pipeline for better performance
Used baked lighting for the environment (reduced real-time cost)
Limited real-time lighting only to the car
Reduced overdraw and controlled material usage (one material, multiple objects)
Applied texture compression
Optimized particle systems (reduced count and lifetime)
