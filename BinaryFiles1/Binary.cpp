
#include "pch.h"
#include <iostream>
#include <vector>
#include <algorithm>
#include <cstring>
#include <string>
#include <fstream>
using namespace std;
vector<int> chocalateNumber;
vector<string> date2;
vector<int> productNumber;
vector<int> shelfLife;
vector<int> degreeOfChocalate;
vector<int> fillingType;
vector<int> _Callories;
vector<int> russianOrNot;
struct Candy {
	vector<int> __russianOrNot;
	vector<int> __Degree;
	vector<int> expirationdates;
	vector<string> dateTimes;
	vector<int> choco;
	vector<int> callories;
	vector<int> _DegreeAndType_Degree;
	vector<int> _DegreeandType_Type;
	int day;
	int month;
	int year;
};

bool sortbysec(const pair<int, int> &a,const pair<int, int> &b) //sorting for the Callories
{
	return (a.second < b.second);
}
char *convert(const std::string & s)
{
	char *pc = new char[s.size() + 1];
	std::strcpy(pc, s.c_str());
	return pc;
};
bool srokgodnosti(int day, int month, int year, int srok) {
	int a = 2019 * 365 + 30 * 3 + 13;
	int b = day + (30 * month) + (365 * year) + (srok * 30);
	if (b >= a)
		return true; //не истёк
	else
		return false; //истёк

}
void istechenie(int month, int year, int srok, int a, int b) {
	month += srok;
	if (month > 12) 
	{
		year += month / 12;
		month = month % 12;
	}
	a = month;
	b = year;
} //высчитывает дату окончания срока годности

int main() 
{
	string line = "";
	string b;
	int a, c, d, f, g, h, j;
	ifstream infile;
	infile.open("Tekst.txt");
	ofstream binaryWrite3("C:\\Users\\mertc\\Documents\\Visual Studio 2017\\Projects\\ConsoleApplication1\\output3.bin",ios::out | ios::binary); //outpu3.bin
	ofstream binaryWrite4("C:\\Users\\mertc\\Documents\\Visual Studio 2017\\Projects\\ConsoleApplication1\\output4.bin", ios::out | ios::binary); //output4.bin
	ofstream binaryWrite2("C:\\Users\\mertc\\Documents\\Visual Studio 2017\\Projects\\ConsoleApplication1\\output2.bin", ios::out | ios::binary); // output2.bin
	ofstream binaryWrite1("C:\\Users\\mertc\\Documents\\Visual Studio 2017\\Projects\\ConsoleApplication1\\output1.bin", ios::out | ios::binary);
	while (!infile.eof())
	{

		getline(infile, line) >> a >> b >> c >> d >> f >> g >> h >> j;
		chocalateNumber.push_back(a);
		productNumber.push_back(c);
		date2.push_back(b);	
		shelfLife.push_back(d);
		degreeOfChocalate.push_back(f);
		fillingType.push_back(g);		
		_Callories.push_back(h);
		russianOrNot.push_back(j);	
	}
	
	/********************/
	if (!_Callories.empty()) {  // output2.bin
		vector<Candy> sorting{};
		sorting.push_back(Candy());
		for (auto s : chocalateNumber) {
			sorting[0].choco.push_back(s);
		}
		for (auto c : _Callories) {
			sorting[0].callories.push_back(c);
		}
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
	//***************** ///
	if (!degreeOfChocalate.empty() && !russianOrNot.empty())  //output3.bin
	{
		vector<int> counter{};  //Counts How many products are russian made and degree of them are more than 80
		vector<Candy> _russianOrNot{};
		_russianOrNot.push_back(Candy());
		for (auto s : russianOrNot) {
			_russianOrNot[0].__russianOrNot.push_back(s);
		}
		for (auto b : degreeOfChocalate){
			_russianOrNot[0].__Degree.push_back(b);
		}
		for (size_t i = 0; i < _russianOrNot[0].__russianOrNot.size()-1; i++)
		{
			if (_russianOrNot[0].__russianOrNot[i] = 1 && _russianOrNot[0].__Degree[i] > 80)
			{			
				binaryWrite3.write((char*)&chocalateNumber[i], chocalateNumber.size() * sizeof(chocalateNumber));
				binaryWrite3.write((char*)&date2[i], date2.size() * sizeof(date2));
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
	/***************************/
	if (!degreeOfChocalate.empty() && !fillingType.empty()) // output4.bin
	{
		vector<int> counterOfProducts{};
		vector<Candy> degreesAndTypes{};
		degreesAndTypes.push_back(Candy());
		for (auto c : degreeOfChocalate) {
			degreesAndTypes[0]._DegreeAndType_Degree.push_back(c);
		}
		for (auto d : fillingType) {
			degreesAndTypes[0]._DegreeandType_Type.push_back(d);
		}
		for (size_t i = 0; i < degreesAndTypes[0]._DegreeAndType_Degree.size()-1; i++)
		{
			if (degreesAndTypes[0]._DegreeandType_Type[i] % 3 == 0 || degreesAndTypes[0]._DegreeAndType_Degree[i] > 50)
			{
			   counterOfProducts.push_back(degreesAndTypes[0]._DegreeAndType_Degree[i]);
               binaryWrite4.write((char*)&chocalateNumber[i], chocalateNumber.size() * sizeof(chocalateNumber));
               binaryWrite4.write((char*)& date2[i], date2.size() * sizeof(date2));
               binaryWrite4.write((char*)&productNumber[i], productNumber.size() * sizeof(productNumber));
			   binaryWrite4.write((char*)&fillingType[i], fillingType.size() * sizeof(fillingType));
			   binaryWrite4.write((char*)&degreeOfChocalate[i], degreeOfChocalate.size() * sizeof(degreeOfChocalate));
			}
		}
		cout << " output4.bin ---> :" << counterOfProducts.size() << endl;
	}  
	if (!date2.empty())
	{
		vector<Candy> expiringDate = {};
		expiringDate.push_back(Candy()); //now vector has index
		for (auto s : date2)
		{
			expiringDate[0].dateTimes.push_back(s);
		}
		for (auto c : shelfLife) {
			expiringDate[0].expirationdates.push_back(c);
		}
		vector<char*>  vc;
		transform(expiringDate[0].dateTimes.begin(), expiringDate[0].dateTimes.end(), std::back_inserter(vc), convert);
		for (size_t i = 0; i < vc.size(); i++)
			cout << vc[i] << std::endl;
		for (size_t i = 0; i < vc.size(); i++)
			delete[] vc[i];
	}
}

	
	















	


	



      


	
