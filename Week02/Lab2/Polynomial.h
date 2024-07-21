#pragma once
#include "Term.h"
#include <vector>

class Polynomial
{
public:
	// Default Constructor
	Polynomial();

	// Getter
	Polynomial GetPolynomial();
	std::vector<Term> GetPolynomialTerms();

	// Setter
	
	// Functions
	void AddTerm(Term term);
	void AddTerm(std::vector<Term> terms);
	int CalculateX(int x);

	void ShowPolynomialEquation();

private:
	std::vector<Term> terms;
};