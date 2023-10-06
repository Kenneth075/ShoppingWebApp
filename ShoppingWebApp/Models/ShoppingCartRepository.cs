using Microsoft.EntityFrameworkCore;
using System.IO.Pipelines;

namespace ShoppingWebApp.Models
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ShoppingWebAppDbContext _shoppingWebAppDbContext;

        private ShoppingCartRepository(ShoppingWebAppDbContext shoppingWebAppDbContext)
        {
           _shoppingWebAppDbContext = shoppingWebAppDbContext;
        }

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;



        public static ShoppingCartRepository GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            ShoppingWebAppDbContext context = services.GetService<ShoppingWebAppDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCartRepository(context) { ShoppingCartId = cartId };
        }

        //ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

        //services.GetRequiredService<IHttpContextAccessor>(): This code is using a dependency injection mechanism
        //(likely provided by an IoC container or framework like ASP.NET Core)
        //to obtain an instance of IHttpContextAccessor.IHttpContextAccessor
        //is an interface that provides access to the current HTTP context.


        //?.HttpContext?.Session: This code uses the null-conditional operator (?.) to safely navigate through a
        //potential chain of null objects.It attempts to get the HttpContext from the IHttpContextAccessor,
        //and then it tries to access the Session property from the HttpContext.If any of these objects is null, session will be assigned null.


        //ShoppingWebAppDbContext context = services.GetService<ShoppingWebAppDbContext>() ?? throw new Exception("Error initializing");

        //services.GetService<ShoppingWebAppDbContext>(): This code is using dependency injection to obtain
        //an instance of the ShoppingWebAppDbContext class, which appears to be a database context used in the application.

        //?? throw new Exception("Error initializing") : The null coalescing operator (??) is used here.
        //If services.GetService<ShoppingWebAppDbContextt>() returns null (i.e., the service is not registered),
        //it throws an exception with the message "Error initializing."
        //This ensures that the context variable is never null, and it's a way to handle the case where a required service is missing.

        //string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

        //session?.GetString("CartId") : This code attempts to get a string value with the key "CartId" from the session object,
        //using the null-conditional operator. If session is null or the value is not present, cartId will be assigned null.

        //?? Guid.NewGuid().ToString(): The null coalescing operator is used again. If cartId is null
        //(either because the session is null or the value is not present in the session),
        //it generates a new GUID using Guid.NewGuid().ToString() and assigns it to cartId.
        //This effectively creates a new "CartId" if one does not exist.

        //session?.SetString("CartId", cartId);

        //session?.SetString("CartId", cartId) : This code attempts to set a string value with the key "CartId"
        //in the session object using the value of cartId.The null-conditional operator ensures that
        //this operation is only performed if session is not null.
        //return new ShoppingChartRepository(context) { ShoppingCartId = cartId };

        //Finally, the method returns a new instance of ShoppingChartRepository initialized with the context,
        //and it sets the ShoppingCartId property of the repository to the cartId.This repository is likely
        //used to manage shopping cart data, and the ShoppingCartId is set to the value obtained or generated earlier.
        //In summary, this code is responsible for obtaining or creating a shopping cart identifier ("CartId")
        //for a user, managing it in the session, and creating a shopping cart repository associated with this
        //identifier using dependency injection.If the required services are not available,
        //it throws an exception to handle initialization errors.The null-conditional and
        //null coalescing operators are used to ensure safe access to objects and properties that might be null.

        public void AddToCart(Pies pie)
        {
            var shoppingCartItem = _shoppingWebAppDbContext.ShoppingCartItems.SingleOrDefault(
               s => s.Pies.PiesId == pie.PiesId && s.ShoppingCartId == ShoppingCartId);  //Checking if there is a shoppingitem in the database.

            if (shoppingCartItem == null)    //If there is no item in the database, we add 1 to it.
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Pies = pie,
                    Amount = 1
                };

                _shoppingWebAppDbContext.ShoppingCartItems.Add(shoppingCartItem); //Adding 1 to to it.
            }
            else
            {
                shoppingCartItem.Amount++;   //If there is an item already, we increase by 1.
            }
            _shoppingWebAppDbContext.SaveChanges(); //Saving the changes made.
        }


        public int RemoveFromCart(Pies pie)
        {
            var shoppingCartItem = _shoppingWebAppDbContext.ShoppingCartItems.SingleOrDefault(
                                   s => s.Pies.PiesId == pie.PiesId && s.ShoppingCartId == ShoppingCartId); //Checking if there is a shoppingitem in the database.

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _shoppingWebAppDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _shoppingWebAppDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??= _shoppingWebAppDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Pies).ToList();
        }

        public void ClearCart()
        {
            var cartItems = _shoppingWebAppDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _shoppingWebAppDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _shoppingWebAppDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _shoppingWebAppDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Pies.Price * c.Amount).Sum();
            return total;
        }
    }
}
    

