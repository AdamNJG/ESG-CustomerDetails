# ESG-CustomerDetails

# General Approach

I decided to restrict the scope of this task to UK customers, as validating data for every different global postCode seemed like a massive scope, and it would be relatively easy to add this later.

I have stuck to TDD where possible, testing new logic (detroit school) and later how the new logic interacts with the flow (london school), allowing TDD to apply XP (eXtreme Programming) for me.
 
There are commented out tests and test helpers, I would usually delete these as I abstract away the initial implementations, ensuring that the original test cases are covered by new ones.

I have applied an approximation Clean Architecture (a mixture of DDD and Hexagonal Architecture) to make my code as modular as possible to adhere to SOLID principals and to apply clear usable API's at all levels of architecture.

I have followed the OpenApi standards on the controller so that it is self documenting, this allows us to send the swagger page to be outputted to static HTML and would be available to developers wishing to consume our API.

I used an inMemeoryDatabase, to make spin up and down as easy as possible, and Unix strings as paths, as they can be used in both Windows and Linux, but Windows paths are not compatible when running in unix systems, this allows for possible future containerisation.

# Input validation
I decided to do the main input validation for the Customer Details within the Server rather than the client, this is so that if we decide to use a different client at a later date, then the validation is already in place, in one place.

If the console is used as potential attack vector, then validating within the console app would only protect the attacker. 

There are holes in my validation pertaining to certain threats such as SQL injection and Stack Smashing, this is slightly negated by the fact that .Net has some inbuilt protections, but my knowledge on internal code security implementations is one of my weak spots (that I am currently studying, working to fix), and this would be something I ask colleagues about.

There is also a need to add validation to retreiving data from the database, to negate the effects of successful sql injection, but again this is something I am unsure of and would have to ask colleagues about.

