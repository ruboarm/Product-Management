# Product-Management

Via the API you can manage products in the database assigned to it.\
The database migration included in the project, so it's very easy to generate new one and work with it.\
DbContext included in Class Library which supports Design-Time generation and ConnectionString provided directly in the DbCotext via overriding OnConfiguring method and providing options to DbContextOptionsBuilder.

It supports Authentication and CRUD operations.

You can test API functionality by using built in Swagger in which included Authentication security or other similar tool like Postman.\
After successful login you can keep the authentication by generated JWT token and test as well functions which require authentication with [Authorize] attribute.
