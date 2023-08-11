

using Microsoft.EntityFrameworkCore;
using simpleproject.repository;

namespace simpleproject.models
{
    public static class seeddata
    {
        
        public static void seedatabase(datacontext context) 
        {

            
            context.Database.Migrate();

            if(context.products.Count() ==0 && context.suppliers.Count() ==0 && context.categories.Count() ==0  ) 
            {
                supplier s1= new supplier() { name = "splash dudes", city ="san jose"};
                supplier s2 = new supplier() { name = "town city", city = "new york" };
                supplier s3 = new supplier() { name = "bulls", city = "chicago" };


                Category c1 = new Category() { name = "watersports" };
                Category c2 = new Category() { name = "soccer" };
                Category c3 = new Category() { name = "chess" };


                context.products.AddRange(
                    
                    new product() { name="kayak", price=275, category= c3, supplier=s1,quality= product.productquality.high },
                    new product() { name = "lifejacket", price = 270, category = c1, supplier = s1, quality = product.productquality.low},
                    new product() { name = "soccer", price = 375, category = c2, supplier = s2,quality = product.productquality.low },
                    new product() { name = "cornerflags", price = 475, category = c2, supplier = s2, quality = product.productquality.high },
                    new product() { name = "stadium", price = 9275, category = c2, supplier = s2 , quality = product.productquality.high },
                    new product() { name = "cap", price = 75, category = c3, supplier = s3 , quality = product.productquality.high },
                    new product() { name = "unsteady chair", price = 2.75m, category = c3, supplier = s3, quality = product.productquality.high },
                    new product() { name = "human chess board", price = 70, category = c3, supplier = s3 , quality = product.productquality.low },
                    new product() { name = "connect4", price = 12, category = c3, supplier = s3 , quality = product.productquality.low }


                    );
                context.SaveChanges();
            }
        }

    }
}
