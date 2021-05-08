#include "BitCalculatorMachine.h"

BitCalculatorMachine::BitCalculatorMachine()
{
}

string BitCalculatorMachine::Calculation(string expr)
{
    expr = '(' + expr + ')';

    ParenthesisMgr mgr;
    parenthesis_t* infoArray[ParenthesisMgr::MAX_PAREN] = {};
    memset(infoArray, 0, sizeof(parenthesis_t*) * ParenthesisMgr::MAX_PAREN);

    //string expr = "(-3 * (((3 + 4)) + (2) + ((((2 * (-3)) + b101) + 3) * 2) + 1))";

    mgr.Get_matching_parentheses(infoArray, expr);

    for (int i = 0; i < ParenthesisMgr::MAX_PAREN; i++)
    {
        if (!infoArray[i])
        {
            break;
        }

        int start = infoArray[i]->opening_index;
        int sub_expr_len = infoArray[i]->closing_index - start + 1;

        string sub_expr = expr.substr(start, sub_expr_len);

        Calculator* cal = new Calculator(sub_expr);
        sub_expr = cal->Calculate();
        delete cal;

        for (int j = 0; j < sub_expr_len; j++)
        {
            if (sub_expr.length() > j)
            {
                expr[start++] = sub_expr[j];
            }
            else
            {
                expr[start++] = ' ';
            }
        }
    }

    for (int i = 0; i < ParenthesisMgr::MAX_PAREN; i++)
    {
        if (infoArray[i])
        {
            delete infoArray[i];
        }
    }

    expr.erase(remove_if(expr.begin(), expr.end(), [](const char ch) {
        return ch == '(' || ch == ')' || ch == ' ';
    }), expr.end());

    return expr;
}
