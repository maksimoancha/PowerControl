// DemoCLibrary.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include <powrprof.h>


extern "C" __declspec(dllexport)  void __cdecl LockUser()
{
	bool ka = LockWorkStation();
}

extern "C" __declspec(dllexport)  void __cdecl PowerOff()
{
	bool ka = ExitWindows(EWX_SHUTDOWN, 0);
}

extern "C" __declspec(dllexport)  void __cdecl UserLogOut()
{
	bool ka = ExitWindowsEx(
		0,  //EWX_LOGOFF
		0x00000000   //SHTDN_REASON_MAJOR_OTHER
	);
}

extern "C" __declspec(dllexport)  void __cdecl RestartSystem()
{
	bool ka = ExitWindowsEx(
		0x00000040,  //EWX_RESTARTAPPS
		0x00000000   //SHTDN_REASON_MAJOR_OTHER
	);
}

extern "C" __declspec(dllexport)  void __cdecl SeepSystem()
{
	BOOLEAN ka = SetSuspendState(FALSE, TRUE, TRUE);
}

extern "C" __declspec(dllexport)  void __cdecl HibernateSystem()
{

	BOOLEAN ka = SetSuspendState(TRUE, TRUE, TRUE);
}