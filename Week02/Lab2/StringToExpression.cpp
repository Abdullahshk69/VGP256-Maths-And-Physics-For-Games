#include "StringToExpression.h"
#include <iostream>

std::vector<Term> StringToExpression::ConvertToPolynomial(std::string input)
{
    // Create required variables
    std::string number;
    std::vector<Term> terms;
    Term term;
    bool hasPushed = false;

    // Clean the string first
    // Remove spaces
    input.erase(std::remove_if(input.begin(), input.end(), std::isspace), input.end());

    // Check the regex of the string


    // Modify checks
    // A term begins and ends based on a sign
    // use for loop to iterate the string
    for (int i = 0; i <= input.size(); i++)
    {
        // Check what type of value is it
        
        // If it is a variable
        if (input[i] == 'x')
        {
            // add number to a Term

            // if the number string is empty
            if (number[0] == '\0')
            {
                term.a = 1;
            }

            // if the number string is just a sign without any number
            else if ((number[0] == '-' || number[0] == '+') && number[1] == '\0')
            {
                number.push_back('1');
                term.a = std::stoi(number);
                number = "";
            }

            // if the number string has a number in it
            else
            {
                term.a = std::stoi(number);
                number = "";
            }

            if (input[i + 1] != '^')
            {
                term.e = 1;
                terms.push_back(term);
                term = { 0,0 };
            }
            continue;
        }

        // It is an exponent
        else if (input[i] == '^')
        {
            // Read the whole number afterwards
            // Add to the exponent
             // Check if next is + or -
            while (!(input[i + 1] == '+' || input[i + 1] == '-' || input[i + 1] == '\0'))
            {
                i++;
                number.push_back(input[i]);
            }

            term.e = std::stoi(number);
            terms.push_back(term);
            number = "";
            hasPushed = true;
        }

        // It is a number
        else
        {
            number.push_back(input[i]);
        }

        // if last number is x-less
        if (input[i] == '\0' && !hasPushed)
        {
            term.a = std::stoi(number);
            terms.push_back(term);
        }
        
        term = { 0,0 };
        hasPushed = false;
    }

    return terms;
}

