Thank you for downloading AKSoftware.Text library 

AKSoftware.Text contains some methods to help you validate your user input with just only one line of code.

In your code just add the following line at the top of your class
using AKSoftware.Text; 

Inside your logic code you can use one of its methods as following:
bool isEmail = Validation.IsEmail("aksoftware98@hotmail.com"); // return true
bool isEmail = Validation.IsEmail("aksoftware98hotmail.com"); // return false