
#include "pch.h"
#include <iostream>
#include <vector>
#include <algorithm>
#include <cstring>
#include <string>
#include <fstream>
#include <ctime>
using namespace std;
int TodayDay = 13;
int TodayMont = 3;
int TodayYear = 2019;
vector<int> chocalateNumber;
vector<string> date2;
vector<int> productNumber;
vector<int> shelfLife;
vector<int> degreeOfChocalate;
vector<int> fillingType;
vector<int> _Callories;
vector<int> russianOrNot;
vector<int> counter;
vector<int> counterOfProducts{};
vector<int> dateDay;
vector<int> dateMonth;
vector<int> dateYear;
struct Candy {
	vector<int> __russianOrNot;
	vector<int> __Degree;
	vector<int> expirationdates;
	vector<string> dateTimes;
	vector<int> choco;
	vector<int> callories;
	vector<int> _DegreeAndType_Degree;
	vector<int> _DegreeandType_Type;
};
vector<Candy> sorting{};
void dateADD(vector<int> &datemonth, vector<int> &dateDay, vector<int>&dateYear, vector<int> &shelfLife, ofstream &binaryWrite1);
void Callories(vector<int> &callories, vector<int> &chocalateNumber);
bool sortbysec(const pair<int, int> &a, const pair<int, int> &b);//sorting for the Callories
void degreeAndFilling(vector<int> &counterOfProducts, vector<int> &degreeOfChocalate, vector<int> &fillingType, ofstream &binaryWrite4);
void degreeAndRussian(vector<int>&counter, vector<int>&degreeofChocalate, ofstream &binaryWrite3, vector<int> russianOrNot);
int main()
{
	string line = "";
	string b;
	int year, month, day;
	char dot;
	int a, c, d, f, g, h, j;
	ifstream infile;
	infile.open("Tekst.txt");
	ofstream binaryWrite3("C:\\Users\\mertc\\Documents\\Visual Studio 2017\\Projects\\ConsoleApplication1\\output3.bin", ios::out | ios::binary); //outpu3.bin
	ofstream binaryWrite4("C:\\Users\\mertc\\Documents\\Visual Studio 2017\\Projects\\ConsoleApplication1\\output4.bin", ios::out | ios::binary); //output4.bin
	ofstream binaryWrite2("C:\\Users\\mertc\\Documents\\Visual Studio 2017\\Projects\\ConsoleApplication1\\output2.bin", ios::out | ios::binary); // output2.bin
	ofstream binaryWrite1("C:\\Users\\mertc\\Documents\\Visual Studio 2017\\Projects\\ConsoleApplication1\\output1.bin", ios::out | ios::binary); // output1.bin
	while (!infile.eof())
	{
		getline(infile, line) >> a >> day >> dot >> month >> dot >> year >> c >> d >> f >> g >> h >> j;
		chocalateNumber.push_back(a);
		productNumber.push_back(c);
		dateDay.push_back(day);
		dateMonth.push_back(month);
		dateYear.push_back(year);
		shelfLife.push_back(d);
		degreeOfChocalate.push_back(f);
		fillingType.push_back(g);
		_Callories.push_back(h);
		russianOrNot.push_back(j);
	}
	if (!dateMonth.empty())
	{
		dateADD(dateMonth, dateDay, dateYear, shelfLife, binaryWrite1); //output 1.bin
	}
	//***************** ///
	if (!degreeOfChocalate.empty() && !russianOrNot.empty())  //output3.bin
	{
		degreeAndRussian(counter, degreeOfChocalate, binaryWrite3, russianOrNot);
	}
	/***************************/
	if (!degreeOfChocalate.empty() && !fillingType.empty()) // output4.bin
	{
		degreeAndFilling(counterOfProducts, degreeOfChocalate, fillingType, binaryWrite4);
	}
	if (!_Callories.empty())
	{  // output2.bin
		sorting.push_back(Candy());
		Callories(_Callories, chocalateNumber);
		vector<pair<int, int>> vect(sorting[0].callories.size() < sorting[0].choco.size() ? sorting[0].callories.size() : sorting[0].choco.size()); //Making pairs of two vectors
		for (unsigned i = 0; i < vect.size(); i++) {
			vect[i] = std::make_pair(sorting[0].choco[i], sorting[0].callories[i]);
			binaryWrite2.write((char*)&chocalateNumber[i], chocalateNumber.size() * sizeof(chocalateNumber));
			binaryWrite2.write((char*)&productNumber[i], productNumber.size() * sizeof(productNumber));
			binaryWrite2.write((char*)&degreeOfChocalate[i], degreeOfChocalate.size() * sizeof(degreeOfChocalate));
		}
		cout << "Callories Which are sorted descendly\n";
		sort(vect.begin(), vect.end(), sortbysec);  //SORTED CALLORIES	
		for (int i = 0; i < vect.size(); i++)
		{
			cout << vect[i].second << " ";
		}
		cout << endl;
	}
}
////////////////////////////////////////////////////////////////////////*********************************************
void degreeAndFilling(vector<int> &counterOfProducts, vector<int> &degreeOfChocalate, vector<int> &fillingType, ofstream &binaryWrite4)
{
	vector<Candy> degreesAndTypes{};
	degreesAndTypes.push_back(Candy());
	for (auto c : degreeOfChocalate)
	{
		degreesAndTypes[0]._DegreeAndType_Degree.push_back(c);
	}
	for (auto s : fillingType)
	{
		degreesAndTypes[0]._DegreeandType_Type.push_back(s);
	}
	for (size_t i = 0; i < degreesAndTypes[0]._DegreeAndType_Degree.size() - 1; i++)
	{
		if (degreesAndTypes[0]._DegreeandType_Type[i] % 3 == 0 || degreesAndTypes[0]._DegreeAndType_Degree[i] > 50)
		{
			counterOfProducts.push_back(degreesAndTypes[0]._DegreeAndType_Degree[i]);
			binaryWrite4.write((char*)&chocalateNumber[i], chocalateNumber.size() * sizeof(chocalateNumber));
			binaryWrite4.write((char*)&productNumber[i], productNumber.size() * sizeof(productNumber));
			binaryWrite4.write((char*)&fillingType[i], fillingType.size() * sizeof(fillingType));
			binaryWrite4.write((char*)&degreeOfChocalate[i], degreeOfChocalate.size() * sizeof(degreeOfChocalate));
		}
	}
	cout << " output4.bin ---> :" << counterOfProducts.size() << endl;
}
void degreeAndRussian(vector<int>&counter, vector<int>&degreeofChocalate, ofstream &binaryWrite3, vector<int> russianOrNot)
{
	vector<Candy> _russianOrNot{};
	_russianOrNot.push_back(Candy());
	for (auto s : russianOrNot) {
		_russianOrNot[0].__russianOrNot.push_back(s);
	}
	for (auto b : degreeOfChocalate) {
		_russianOrNot[0].__Degree.push_back(b);
	}
	for (size_t i = 0; i < _russianOrNot[0].__russianOrNot.size(); i++)
	{
		if (_russianOrNot[0].__russianOrNot[i] = 1 && _russianOrNot[0].__Degree[i] > 80)
		{
			binaryWrite3.write((char*)&chocalateNumber[i], chocalateNumber.size() * sizeof(chocalateNumber));
			binaryWrite3.write((char*)&productNumber[i], productNumber.size() * sizeof(productNumber));
			binaryWrite3.write((char*)&shelfLife[i], shelfLife.size() * sizeof(shelfLife));
			binaryWrite3.write((char*)&degreeOfChocalate[i], degreeOfChocalate.size() * sizeof(degreeOfChocalate));
			binaryWrite3.write((char*)&fillingType[i], fillingType.size() * sizeof(fillingType));
			binaryWrite3.write((char*)&_Callories[i], _Callories.size() * sizeof(_Callories));
			counter.push_back(_russianOrNot[0].__Degree[i]);
			// cout << _russianOrNot[0].__russianOrNot[i]<<" " << _russianOrNot[0].__Degree[i] << " "<< endl; //products which are russian made , and degree > 80								
		}
	}
	cout << " output3.bin---> :" << counter.size() << endl;;
}
void Callories(vector<int> &callories, vector<int> &chocalateNumber)
{
	for (auto s : chocalateNumber)
	{
		sorting[0].choco.push_back(s);
	}
	for (auto c : callories)
	{
		sorting[0].callories.push_back(c);
	}
}
bool sortbysec(const pair<int, int> &a, const pair<int, int> &b)//sorting for the Callories
{
	return (a.second < b.second);
}
void dateADD(vector<int> &datemonth, vector<int> &dateDay, vector<int>&dateYear, vector<int> &shelfLife, ofstream &binaryWrite1)
{
	vector<int> datemonth2(dateMonth);
	vector<int>dateday2(dateDay);
	vector<int>dateyear2(dateYear);
	for (int i = 0; i < dateMonth.size(); i++)
	{
		dateMonth[i] += shelfLife[i];
		if (dateMonth[i] > 12)
		{
			dateYear[i] += 1;
		}
		if (dateYear[i] > TodayYear)
		{
			cout << dateday2[i] << "." << datemonth2[i] << "." << dateyear2[i] << "<--- This is Out dated " << endl;
		}
		if (dateYear[i] == TodayYear && dateMonth[i] > TodayMont)
		{
			cout << dateday2[i] << "." << datemonth2[i] << "." << dateyear2[i] << "<--- This is OUT dated" << endl;
		}
	}
	for (size_t i = 0; i < datemonth.size(); i++)
	{
		binaryWrite1.write((char*)&chocalateNumber[i], chocalateNumber.size() * sizeof(chocalateNumber));
		binaryWrite1.write((char*)&productNumber[i], productNumber.size() * sizeof(productNumber));
		binaryWrite1.write((char*)&shelfLife[i], shelfLife.size() * sizeof(shelfLife));
	}
}