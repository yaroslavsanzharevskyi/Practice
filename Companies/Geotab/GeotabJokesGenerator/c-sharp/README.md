## Change Log

1. Remove ConsolePrinter Class

Justification:
The class was redundant and didn’t provide meaningful abstraction for console interaction. Removing it simplifies the code and improves maintainability.

2. Rename JsonFeed to GeotabJokesStore

Justification:
The new name clearly reflects the class’s role in fetching jokes from the Geotab API, enhancing readability and clarity.

3. Refactor GeotabJokesStore Logic

Justification:
	•	Use HttpClientFactory: Prevents socket exhaustion and follows best practices for HttpClient management.
	•	Update GetRandomJokes Method: Allows returning the exact number of jokes requested, improving flexibility.
	•	Non-static Methods: Promotes better testability and allows dependency injection.
	•	Remove Default Constructor: Reduces unnecessary complexity.
	•	Fix Input Sequence: Ensures proper handling of category input for better user experience.
	•	Simplify Query Composition: Reduces errors and enhances readability.

4. Refactor Program Class

Justification:
	•	Remove Extra Wrappers: Simplifies the flow by removing unnecessary methods.
	•	Print Jokes Directly: Makes the program more functional and reduces state management.
	•	Add Quit Command: Provides users with an easy way to exit the program.

5. Add Input Validation

Justification:
Ensures correct user input and prevents errors, improving the program’s robustness and user experience.

6. Make Main Method Async

Justification:
Improves readability and allows non-blocking I/O, enhancing performance and responsiveness.

7. Add Unit Tests

