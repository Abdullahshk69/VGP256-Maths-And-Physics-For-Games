#include "Polynomial.h"

Polynomial::Polynomial()
{
}

std::vector<Term> Polynomial::GetTerm()
{
	return terms;
}

void Polynomial::AddTerm(Term term)
{
	terms.push_back(term);
}
