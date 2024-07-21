#include "Polynomial.h"
#include <iostream>

Polynomial::Polynomial()
{
}

Polynomial Polynomial::GetPolynomial()
{
	return *this;
}

std::vector<Term> Polynomial::GetPolynomialTerms()
{
	return terms;
}

void Polynomial::AddTerm(Term term)
{
	terms.push_back(term);
}

void Polynomial::AddTerm(std::vector<Term> terms)
{
	this->terms = terms;
}

int Polynomial::CalculateX(int x)
{
	int total = 0;
	for (Term& t : terms)
	{
		total += t.a * (std::pow(x, t.e));
	}
	return total;
}

void Polynomial::ShowPolynomialEquation()
{
	if (terms.size() == 0)
	{
		return;
	}

	std::cout << terms[0];
	for (size_t t = 1; t < terms.size(); t++)
	{
		if (terms[t].a >= 0)
		{
			std::cout << "+";
		}
		std::cout << terms[t];
	}
	std::cout << std::endl;
}
