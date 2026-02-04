// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"

extern "C" __declspec(dllexport)
int Multiple(int a, int b)
{
    return a * b;
}