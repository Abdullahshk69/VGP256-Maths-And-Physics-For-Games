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

private:
	std::vector<Term> terms;
};