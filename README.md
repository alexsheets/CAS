A small site I created using C#/dotNET ASP.NET MVC framework to allow students to perform self-evaluations, by evaluated by their professors, view their results in comparison to others, leave reflections at the end of their semester, and more. Supports thousands of students and hundreds of evaluators.

Uses authentication to ensure users are in the active directory as well as in our database (students and evaluators are uploaded to ensure they should be using this application).

Database connection via SQL using Entity Framework models and DbContext connection. The GetDbItems and SetDbItems in the /classes subdirectory are used as an easy abstraction for getting and setting database items.


YAML file in repository is an example of the CI/CD setup file I composed for our use.
