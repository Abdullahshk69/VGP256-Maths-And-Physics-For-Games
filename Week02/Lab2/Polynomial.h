#pragma once
#include "Term.h"
#include <vector>

class Polynomial
{
public:
	// Default Constructor
	Polynomial();

	// Getter
	std::vector<Term> GetTerm();

	// Setter
	
	// Functions
	void AddTerm(Term term);
	void AddTerm(std::vector<Term> terms);

	void ShowPolynomialEquation();

private:
	std::vector<Term> terms;
};