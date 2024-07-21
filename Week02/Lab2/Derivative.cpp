#include "Derivative.h"
#include <vector>

Polynomial Derivative::SingleDerivative(Polynomial poly)
{
	std::vector<Term> terms = poly.GetPolynomialTerms();

	std::vector<Term> dTerms;
	for (size_t t = 0; t < terms.size(); t++)
	{
		dTerms.push_back({ terms[t].a * terms[t].e, terms[t].e - 1 });
	}
	poly.AddTerm(dTerms);
	return poly;
}
