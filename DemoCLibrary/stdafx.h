// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#include "targetver.h"

#define WIN32_LEAN_AND_MEAN             // Exclude rarely-used stuff from Windows headers
// Windows Header Files:
#include <windows.h>
#include <tchar.h>
#include <powrprof.h>

#pragma comment(lib, "PowrProf.lib")


// TODO: reference additional headers your program requires here

extern "C" __declspec(dllexport)  void __cdecl LockUser();
extern "C" __declspec(dllexport)  void __cdecl PowerOff();
extern "C" __declspec(dllexport)  void __cdecl UserLogOut();
extern "C" __declspec(dllexport)  void __cdecl RestartSystem();
extern "C" __declspec(dllexport)  void __cdecl SeepSystem();
extern "C" __declspec(dllexport)  void __cdecl HibernateSystem();
