# Improvements considered
- Checking strings to be either null or empty
- Using C# library for checking upper case
- Using string empty in cases of empty ones for memory improvement
- Using StringBuilder to append in case of big array of characters as is it a mutable one and can be extended. References for benchmark:
    - https://www.infoworld.com/article/3616600/when-to-use-string-vs-stringbuilder-in-net-core.html
- Using Dependency Injection for extendibility
- Better structing of the project and separation of concepts following better design
- Added Tests
- Using Mock for Dependency Injection of tests