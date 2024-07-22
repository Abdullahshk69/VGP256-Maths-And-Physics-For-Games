#include "Derivative.h"
#include <vector>

Polynomial Derivative::SingleDerivative(Polynomial poly)
{
	std::vector<Term> terms = poly.GetPolynomialTerms();

	std::vector<Term> dTerms;
	Term temp;
	for (size_t t = 0; t < terms.size(); t++)
	{
		temp = { terms[t].a * terms[t].e, terms[t].e - 1 };
		if (temp.a != 0)
		{
			dTerms.push_back(temp);
		}
	}
	poly.AddTerm(dTerms);

	int nullTerms = 0;
	return poly;
}
