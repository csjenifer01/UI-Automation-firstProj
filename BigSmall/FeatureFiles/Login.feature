Feature: Login

A short summary of the feature

@tag1
Scenario Outline: To check user Sign In with Invalid Credentials
	Given User is on homepage
	When User clicks on sign in
	And User enters the Invalid Email <email>
	And User enters the Invalid Password <password>
	And User clicks on the Sign In button
	Then An error message should be displayed

Examples:
	| email                    | password|
	| csjenifer@gmail.com      | Helen0@ |
	| helen@yahoo.com          | hele123 |