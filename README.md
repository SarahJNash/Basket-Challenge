# Basket Test
I imagine that a UI would be produced that displays the products and then the user adds them one at a time to a basket. This UI would use the class libraries that have been created for this challenge. 


## Assumptions
I was initially confused by the Hat product, I assumed this was headgear but looking closely at the scenarios I realised that it wasn't.


## Design Decisions 
* I decided to not store the quantity of the items in the basket but allow duplicates, this simplifies the calculation code. However it could be possible to add the quantity functionality to the basket class, and have some code within there that created the duplicate items, or even just leave it up to the UI to group them.
*  Product.id would be a guid in real life but for ease of coding I have made it an int.
* In the ProductService, I manually mapped the data entity to the domain model. I could have used something like AutoMapper, but find the complexity that often ends up in the mappers (which aren't easy to understand) negates their benefit's just for the sake of a few mins typing everything.
* The ProductRepository just returns a hardcoded collection of products. It should be using a real data database.
* I didn’t create repositories for the gift vouchers or offer vouchers, but in reality these too should be stored somewhere. Vouchers entered by users could then be checked to make sure they were valid.

### Gift Voucher service 
Originally I had the GiftVoucher class inheriting from the Voucher class and therefore the validation code was within the Apply() function. When thinking about multiple vouchers being applied I realised this code would be run for every voucher. I also thought about a scenario where the total of the gift vouchers came to more than the total of the basket, it would be really hard to do this within the Apply method without passing in values that an offer voucher would never require. 


## Testing 
I have treated the scenarios given in the challenge as integration test so nothing is mocked and data is returned from the repository, all other tests have been mocked.


## Improvements 
* Product category needs more items in it. Thinking about it now, this should be a string because it potentially violates the Open/Closed SOLID principle because new categories mean the code has to be recompiled. 
* In a real world application with a ui the concrete version of IGiftService, IProductService and IProductRepository would be injected using an IOC container.
* The ProductRepository should be hooked up to a real database. Using Entity Framework, I could set up migrations so that a developer could generate their own test database to use.
* Error handling isn’t amazing, I would have some kind of logging functionality added and have more guards against incorrect ids etc...