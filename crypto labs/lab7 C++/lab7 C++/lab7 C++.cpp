#include "stdafx.h"
#include <iostream>
using namespace std;

#define PadRight(num, bit) ((num >> bit) | (num << (32 - bit))) 
#define PadLeft(num, bit) ((num << bit) | (num >> (32 - bit))) 


int main()
{
	cout << PadLeft(255u, 2) << endl;
	cout << PadRight(255u, 2) << endl;

	char s;
	cin >> s;
}

