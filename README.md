# Basket Test
This solution provides only a portion of a complete application. It has the class libraries required to fill the spec and some tests that call them. 



I imagine that a UI would be produced that displays the products and then adds them one at a time to a basket. This means that products would be added to a basket by id. 
The system would then retrieve the data from a database making sure the user could never change a product. 

 There would be a Basket.Data project that would get (perhaps even set) the data




## Assumptions
I was initally confused by the Hat product, I assumed this was headgear but looking closely at the scenarios i realised that it wasn't.
I have assumed that the consumer of the classes will add vouchers or items to the basket 1 at a time and on any change it will recalculate the total 

## Improvements 
Product category needs more items in it. Possibly this should be a string becuase it potentially violates the Open/Closed SOLID principle because new categories mean the code has to be recompiled. 



# Gift Voucher service 

Originally I had the GiftVoucher class inheriting from the Voucher class and therefore the validation code was within the apply() function.
When thinking about multiple vouchers being applied I realised this code would be run for every voucher and there was no way of warning the user 
that the voucher was worth more than the basket.  

In a real world application with a ui the concrete version of IGiftService would be injected using an IOC container. 

